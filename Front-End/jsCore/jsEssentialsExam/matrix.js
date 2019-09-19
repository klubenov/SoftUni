function sumMatrix(matrix1, matrix2){
    let matLength = matrix1.length;
    let innerMatLength = matrix1[0].length;

    let resultMatrix = [];

    let remainder = 0;
    for (let i = 0; i < matLength; i++){
        resultMatrix[i] = [];

        for (let j = 0; j < innerMatLength; j++){
            let result = matrix1[i][j] + matrix2[i][j] + remainder;

            if(result > 9){
                remainder = result - 9;
                result = 9;
            } else {
                remainder = 0;
            }

            resultMatrix[i][j] = result;
        }

        if(remainder !== 0){
            let addCells = Math.floor(remainder / 9);
            let isThereExtraCell = remainder % 9 !== 0;

            if(isThereExtraCell){
                addCells++;
            }
            debugger;
            if(addCells <= 1){
                resultMatrix[i][resultMatrix[i].length] = remainder;
                remainder = 0;
            } else {
                for(let c = 0; c < addCells; c++){
                    if(remainder > 9){
                        resultMatrix[i][innerMatLength+c] = 9;
                        remainder -= 9;
                    } else {
                        resultMatrix[i][innerMatLength+c] = remainder;
                        remainder = 0
                    }
                }
            }
        }
    }

    

    console.log(JSON.stringify(resultMatrix));
}
sumMatrix([[9, 9], [4, 7]],
    [[9, 9], [1, 2]]);