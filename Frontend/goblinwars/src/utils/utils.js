import Moment from "moment";

export const colorTypeGradients = (type1, type2, length) => {

    // debugger
    let color1, color2;

    switch (type1) {
        case "grass":
            color1 = "#a8ff98";
            break;
        case "poison":
            color1 = "#d6a2e4";
            break;
        case "normal":
            color1 = "#dcdcdc";
            break;
        case "fire":
            color1 = "#ffb971";
            break;
        case "water":
            color1 = "#8cc4e2";
            break;
        case "electric":
            color1 = "#ffe662";
            break;
        case "ice":
            color1 = "#8cf5e4";
            break;
        case "fighting":
            color1 = "#da7589";
            break;
        case "ground":
            color1 = "#e69a74";
            break;
        case "flying":
            color1 = "#bbc9e4";
            break;
        case "psychic":
            color1 = "#ffa5da";
            break;
        case "bug":
            color1 = "#bae05f";
            break;
        case "rock":
            color1 = "#C9BB8A";
            break;
        case "ghost":
            color1 = "#8291e0";
            break;
        case "dark":
            color1 = "#8e8c94";
            break;
        case "dragon":
            color1 = "#88a2e8";
            break;
        case "steel":
            color1 = "#9fb8b9";
            break;
        case "fairy":
            color1 = "#fdb9e9";
            break;
        default:
            color1 = "gainsboro";
            break;
    }

    if (length === 2) {

        switch (type2) {
            case "grass":
                color2 = "#a8ff98";
                break;
            case "poison":
                color2 = "#d6a2e4";
                break;
            case "normal":
                color2 = "#dcdcdc";
                break;
            case "fire":
                color2 = "#ffb971";
                break;
            case "water":
                color2 = "#8cc4e2";
                break;
            case "electric":
                color2 = "#ffe662";
                break;
            case "ice":
                color2 = "#8cf5e4";
                break;
            case "fighting":
                color2 = "#da7589";
                break;
            case "ground":
                color2 = "#e69a74";
                break;
            case "flying":
                color2 = "#bbc9e4";
                break;
            case "psychic":
                color2 = "#ffa5da";
                break;
            case "bug":
                color2 = "#bae05f";
                break;
            case "rock":
                color2 = "#C9BB8A";
                break;
            case "ghost":
                color2 = "#8291e0";
                break;
            case "dark":
                color2 = "#8e8c94";
                break;
            case "dragon":
                color2 = "#88a2e8";
                break;
            case "steel":
                color2 = "#9fb8b9";
                break;
            case "fairy":
                color2 = "#fdb9e9";
                break;
            default:
                color2 = "gainsboro";
                break;
        }
    } else if (length === 1) {
        color2 = color1;
    }

    const finalColor = [color1,color2];

    return finalColor;

}

const LightenDarkenColor = function(col, amt) {
  
    var usePound = false;
  
    if (col[0] == "#") {
        col = col.slice(1);
        usePound = true;
    }
 
    var num = parseInt(col,16);
 
    var r = (num >> 16) + amt;
 
    if (r > 255) r = 255;
    else if  (r < 0) r = 0;
 
    var b = ((num >> 8) & 0x00FF) + amt;
 
    if (b > 255) b = 255;
    else if  (b < 0) b = 0;
 
    var g = (num & 0x0000FF) + amt;
 
    if (g > 255) g = 255;
    else if (g < 0) g = 0;
 
    return (usePound?"#":"") + (g | (b << 8) | (r << 16)).toString(16);
  
}

const ValidateEmail = function(email) {
  const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
  return re.test(email);
}

const GetDuration = function(miliseconds, simplified=false) {
    var dur = Moment.duration(miliseconds);
    var hours = Math.floor(dur.asHours());
    var mins  = Math.floor(dur.asMinutes()) - hours * 60;
    var sec   = Math.floor(dur.asSeconds()) - hours * 60 * 60 - mins * 60;
    if(simplified)
        return hours + "h"
    else
        return ((hours > 9) ? hours : ("0"+hours)) + ":" + ((mins > 9) ? mins : ("0"+mins)) + ":" + ((sec > 9) ? sec : ("0"+sec));
}

export { LightenDarkenColor, ValidateEmail , GetDuration }