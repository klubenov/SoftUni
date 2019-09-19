function autoService (input){
    let availableParts = {};
    let availableInstructions = [];

    input.forEach(entry => {
        if(entry.startsWith('instructions')){
            let instruction = entry.split(' ')[1];
            if(!availableInstructions.includes(instruction)){
                availableInstructions.push(instruction);
            } 
        } else if (entry.startsWith('addPart')){
            let data = entry.split(' ');
            let manf = data[1];
            let partType = data[2];
            let partNum = data[3];
            if(!availableParts.hasOwnProperty(manf)){
                availableParts[manf] = {};
            }
            if(!availableParts[manf].hasOwnProperty(partType)){
                availableParts[manf][partType] = [];
            }
            availableParts[manf][partType].push(partNum);
        } else if (entry.startsWith('repair')){
            let data = entry.split(' ');
            let manf = data[1];
            let repairObj = JSON.parse(data[2]);

            if(availableInstructions.includes(manf)){
                for(let partType in repairObj){
                    if(repairObj[partType] === 'broken'){
                        if(availableParts.hasOwnProperty(manf)){
                            if(availableParts[manf].hasOwnProperty(partType)){
                                if(availableParts[manf][partType][0]){
                                    repairObj[partType] = availableParts[manf][partType][0];
                                }
                                availableParts[manf][partType].splice(0, 1);
                            }
                        }
                    }
                }
                let resultRepairObj = JSON.stringify(repairObj);
                console.log(`${manf} client - ${resultRepairObj}`);

            } else {
                console.log(`${manf} is not supported`);
            }
        }
    });

    let resultPartsArray = [];



    for(let manf in availableParts){
        let resultobj = {
            name: manf,
            innerObj: availableParts[manf]
        }
        resultPartsArray.push(resultobj);

        //let resultPart = JSON.stringify(availableParts[manf]);
        //console.log(`${manf} - ${resultPart}`);
    }

    resultPartsArray.sort((a,b) => a.name > b.name);
    resultPartsArray.forEach(arr => {
        console.log(`${arr.name} - ${JSON.stringify(arr.innerObj)}`)
    })
}

autoService([
    'instructions bmw',    
    'addPart opel engine GV1399SSS',
    'addPart opel transmission SMF556SRG',
    'addPart bmw engine GV1399SSS',   
    'addPart bmw transmission SMF444ORG',
    'addPart opel transmission SMF444ORG',
    'instructions opel',
    'repair opel {"engine":"broken","transmission":"OP8766TRS"}',
      'repair bmw {"engine":"ENG999FPH","transmission":"broken","wheels":"broken"}'
  ]
  );