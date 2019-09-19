function vat(vatPrice, vatPercentage){
    let priceWithoutVat =  vatPrice / (1.00 + vatPercentage / 100.00);

    //priceWithoutVat =  Math.round(priceWithoutVat);

    return priceWithoutVat.toFixed(2);
}

console.log(vat(220.00,
    10.00));