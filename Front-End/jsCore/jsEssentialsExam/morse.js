function morse (input){
    let alpha = {  
        "-----":"0",
        ".----":"1",
        "..---":"2",
        "...--":"3",
        "....-":"4",
        ".....":"5",
        "-....":"6",
        "--...":"7",
        "---..":"8",
        "----.":"9",
        ".-":"a",
        "-...":"b",
        "-.-.":"c",
        "-..":"d",
        ".":"e",
        "..-.":"f",
        "--.":"g",
        "....":"h",
        "..":"i",
        ".---":"j",
        "-.-":"k",
        ".-..":"l",
        "--":"m",
        "-.":"n",
        "---":"o",
        ".--.":"p",
        "--.-":"q",
        ".-.":"r",
        "...":"s",
        "-":"t",
        "..-":"u",
        "...-":"v",
        ".--":"w",
        "-..-":"x",
        "-.--":"y",
        "--..":"z",
        "/":" ",
        "-·-·--":"!",
        "·-·-·-":".",
        "--··--":","
     };

     let inputArr = input.split(' ');
     let result = '';
     inputArr.forEach(element => {
         result += alpha[element];
     });

     console.log(result);
}

morse('... - .- -.-. -.- --- ...- . .-. ..-. .-.. --- .--');