const regBtn = document.getElementById("regBtn");
const loginBtn = document.getElementById("loginBtn");

const baseForm = document.getElementById("base-f");
const loginForm = document.getElementById("login-f");
const regForm = document.getElementById("reg-f");

regBtn.addEventListener("click", (e) => {
    baseForm.style.display = "none";
    loginForm.style.display = "none";
    regForm.style.display = "flex";
});

loginBtn.addEventListener("click", (e) => {

});