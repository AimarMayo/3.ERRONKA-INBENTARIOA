document.addEventListener("DOMContentLoaded", function () {
  emailjs.init("b3sZSjYEyGojEY7B8");

  const formularioa = document.getElementById("formularioa");
  const erantzuna = document.getElementById("erantzuna");

  if (formularioa) {
    formularioa.addEventListener("submit", function (e) {
      e.preventDefault();

    
      if (!formularioa.checkValidity()) {
        formularioa.reportValidity();
        return;
      }

    
      emailjs.sendForm("service_co875ff", "template_gdxths9", this)
        .then(function (response) {
          console.log("OK:", response);
          erantzuna.textContent = "Mezua bidali da!";
          erantzuna.classList.remove("text-danger");
          erantzuna.classList.add("text-success");
          formularioa.reset();
        })
        .catch(function (error) {
          console.error("EMAILJS ERROR:", error);
          erantzuna.textContent = "Errorea gertatu da.";
          erantzuna.classList.remove("text-success");
          erantzuna.classList.add("text-danger");
        });
    });
  }
});