document.addEventListener("DOMContentLoaded", function () {
    const body = document.body;
    const themeToggle = document.getElementById("theme-toggle");

    // Verificar o tema salvo no Cookie via backend
    fetch('/Home/GetTheme')
        .then(response => response.json())
        .then(data => {
            if (data.theme === "dark") {
                body.classList.add("dark-theme");
                themeToggle.innerHTML = '<i class="fas fa-sun"></i> Tema Claro';
            } else {
                body.classList.remove("dark-theme");
                themeToggle.innerHTML = '<i class="fas fa-moon"></i> Tema Escuro';
            }
        });

    // Alternar o tema com transição suave
    themeToggle.addEventListener("click", () => {
        const isDark = body.classList.toggle("dark-theme");

        themeToggle.innerHTML = isDark
            ? '<i class="fas fa-sun"></i> Tema Claro'
            : '<i class="fas fa-moon"></i> Tema Escuro';

        fetch('/Home/ToggleTheme', {
            method: 'POST',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ theme: isDark ? "dark" : "light" })
        });

        body.classList.add("theme-transition");
        setTimeout(() => {
            body.classList.remove("theme-transition");
        }, 500);
    });
});