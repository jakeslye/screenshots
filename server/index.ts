const express = require('express');
var bodyParser = require('body-parser');
const fs = require("fs");

const app = express();

app.use(bodyParser.json({limit: '50mb'}) );
app.use(bodyParser.urlencoded({
  limit: '50mb',
  extended: true,
  parameterLimit:50000
}));

startUrls();

app.get("/", (req: any, res:any) => {
  res.send("Private image hosting programmed by jake. Message me if you belive you should have access.");
})

app.get("/info", (req: any, res:any) => {
  var amount = 0;
  var size = 0;
  fs.readdir("images/", function (err: any, files: any) {
    if (err) {
      return console.log('Unable to scan directory: ' + err);
    }
    amount = files.length;
    files.forEach(function (file: any) {
      size = fs.statSync("images/" + file).size / 1000000;
    });
    res.send({ amount: amount, size: size});
  });
})

app.get("/http", (req: any, res:any) => {
  //I know this is bad :(
  const image = req.query.id;
  const page = `<!DOCTYPE html>
                  <html>
                    <head>
                      <meta property="og:title" content="Image">
                      <meta data-rh="true" property="og:image"content="https://screenshot-server.jakethethe1.repl.co/images/` + image + `"/>
                      <meta data-rh="true" name="twitter:card" content="summary_large_image"/>
                    </head>
                    <body>
                      <script>
                        window.location.href = "/";
                      </script>
                    </body>
                  </html>`
  res.send(page);
})

app.post('/upload',(req: any, res: any) => {
  var username = req.body.username;
  var password = req.body.password;
  if(login(username,password)){
    var id = makeid(6);
    if (!fs.existsSync("images/" + id + ".jpg")) {
      var imageBuffer = Buffer.from(req.body.image, "base64");
      fs.writeFileSync("images/" + id + ".jpg", imageBuffer);
      updateUrls(id);
      res.send(id + ".jpg");
    }
  }
});

app.post('/login', (req: any, res: any) => {
  var username = req.body.username;
  var password = req.body.password;
  if(login(username,password)){
    res.send("good");
  }else{
    res.send("fail");
  }
});

app.listen(() => {
  console.log('Server started');
});

function startUrls(){
  fs.readdir("images/", function (err: any, files: any) {
    if (err) {
      return console.log('Unable to scan directory: ' + err);
    } 
    files.forEach(function (file: any) {
      app.get('/images/' + file, (req: any, res: any) => {
        res.sendFile("/home/runner/Screenshot-server/images/" + file);
      });
    });
  });
}

function updateUrls(newImg: string){
  app.get('/images/' + newImg + ".jpg", (req: any, res: any) => {
    res.sendFile("/home/runner/Screenshot-server/images/" + newImg + ".jpg");
  });
}

//This is where you could implement a real login system
function login(username: string, password: string){
  if(username == "jake" && password == "password"){
    return true;
  }else{
    return false;
  }
}

function makeid(length: number) {
    var result           = '';
    var characters       = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for ( var i = 0; i < length; i++ ) {
      result += characters.charAt(Math.floor(Math.random() * 
 charactersLength));
   }
   return result;
}