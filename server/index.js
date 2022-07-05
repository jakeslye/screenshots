var express = require('express');
var bodyParser = require('body-parser');
var fs = require("fs");
var app = express();
app.use(bodyParser.json({ limit: '50mb' }));
app.use(bodyParser.urlencoded({
    limit: '50mb',
    extended: true,
    parameterLimit: 50000
}));
startUrls();
app.get("/", function (req, res) {
    res.send("Private image hosting programmed by jake. Message me if you belive you should have access.");
});
app.get("/info", function (req, res) {
    var amount = 0;
    var size = 0;
    fs.readdir("images/", function (err, files) {
        if (err) {
            return console.log('Unable to scan directory: ' + err);
        }
        amount = files.length;
        files.forEach(function (file) {
            size = fs.statSync("images/" + file).size / 1000000;
        });
        res.send({ amount: amount, size: size });
    });
});
app.get("/http", function (req, res) {
    //I know this is bad :(
    var image = req.query.id;
    var page = "<!DOCTYPE html>\n                  <html>\n                    <head>\n                      <meta property=\"og:title\" content=\"Image\">\n                      <meta data-rh=\"true\" property=\"og:image\"content=\"https://screenshot-server.jakethethe1.repl.co/images/" + image + "\"/>\n                      <meta data-rh=\"true\" name=\"twitter:card\" content=\"summary_large_image\"/>\n                    </head>\n                    <body>\n                      <script>\n                        window.location.href = \"/\";\n                      </script>\n                    </body>\n                  </html>";
    res.send(page);
});
app.post('/upload', function (req, res) {
    var username = req.body.username;
    var password = req.body.password;
    if (login(username, password)) {
        var id = makeid(6);
        if (!fs.existsSync("images/" + id + ".jpg")) {
            var imageBuffer = Buffer.from(req.body.image, "base64");
            fs.writeFileSync("images/" + id + ".jpg", imageBuffer);
            updateUrls(id);
            res.send(id + ".jpg");
        }
    }
});
app.post('/login', function (req, res) {
    var username = req.body.username;
    var password = req.body.password;
    if (login(username, password)) {
        res.send("good");
    }
    else {
        res.send("fail");
    }
});
app.listen(function () {
    console.log('Server started');
});
function startUrls() {
    fs.readdir("images/", function (err, files) {
        if (err) {
            return console.log('Unable to scan directory: ' + err);
        }
        files.forEach(function (file) {
            app.get('/images/' + file, function (req, res) {
                res.sendFile("/home/runner/Screenshot-server/images/" + file);
            });
        });
    });
}
function updateUrls(newImg) {
    app.get('/images/' + newImg + ".jpg", function (req, res) {
        res.sendFile("/home/runner/Screenshot-server/images/" + newImg + ".jpg");
    });
}
//This is where you could implement a real login system
function login(username, password) {
    if (username == "jake" && password == "password") {
        return true;
    }
    else {
        return false;
    }
}
function makeid(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() *
            charactersLength));
    }
    return result;
}
