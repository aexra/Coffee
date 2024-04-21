const regBtn = document.getElementById("regBtn");
const loginBtn = document.getElementById("loginBtn");

const baseForm = document.getElementById("base-f");
const loginForm = document.getElementById("login-f");
const regForm = document.getElementById("reg-f");

const applyRegisterBtn = document.getElementById("applyRegisterBtn");
const closeRegFormBtn = document.getElementById("closeRegFormBtn");

regBtn.addEventListener("click", (e) => {
    if (!regConditionHandler()) return;

    switchFrame(1);
});

loginBtn.addEventListener("click", (e) => {
    switchFrame(2);
});

applyRegisterBtn.addEventListener("click", (e) => {

});

closeRegFormBtn.addEventListener("click", (e) => {
    switchFrame(0);
});

// Здесь нужно прописать условие перехода на фрейм регистрации
function regConditionHandler() {
    return true;
}

// Здесь нужно прописать логику регистрации
function registerNewUser() {

}


function switchFrame(i) {
    switch (i) {
        case 0:
            baseForm.style.display = "flex";
            regForm.style.display = "none";
            loginForm.style.display = "none";
            break;
        case 1:
            baseForm.style.display = "none";
            regForm.style.display = "flex";
            loginForm.style.display = "none";
            break;
        case 2:
            baseForm.style.display = "none";
            regForm.style.display = "none";
            loginForm.style.display = "flex";
            break;
        default:
            break;
    }
}