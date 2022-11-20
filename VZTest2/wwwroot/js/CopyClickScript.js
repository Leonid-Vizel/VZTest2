const fadeOut = [{ transform: 'opacity:0;' }];
const fadeIn = [{ transform: 'opacity:1;' }];

const timing = {
    duration: 500,
    iterations: 1,
}

function CopyClick(id) {
    navigator.clipboard.writeText(id);
    let button = document.getElementById(`copyBtn-${id}`);
    button.setAttribute('class', 'bi bi-check2');
    setInterval(function () { button.setAttribute('class', 'bi bi-clipboard'); }, 2500);
}