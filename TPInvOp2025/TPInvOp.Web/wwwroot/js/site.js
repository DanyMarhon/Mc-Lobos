const iniciarTinyMCE = () => {
    const tema = document.querySelector("body").getAttribute("data-bs-theme");
    tinymce.remove();

    tinymce.init({
        selector: 'textarea',
        plugins: 'anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount',
        toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table | align lineheight | numlist bullist indent outdent | emoticons charmap | removeformat',
        skin: tema === "dark" ? "oxide-dark" : "oxide",
        content_css: tema === "dark" ? "dark" : "default",
    });
}

const temaOscuro = () => {
    document.querySelector("body").setAttribute("data-bs-theme", "dark");
    document.querySelector("#d1-icon").setAttribute("class", "bi bi-sun-fill");
    localStorage.setItem("tema", "dark");
    iniciarTinyMCE();
}

const temaClaro = () => {
    document.querySelector("body").setAttribute("data-bs-theme", "light");
    document.querySelector("#d1-icon").setAttribute("class", "bi bi-moon-fill");
    localStorage.setItem("tema", "light");
    iniciarTinyMCE();
}

const cambiarTema = () => {
    const actual = document.querySelector("body").getAttribute("data-bs-theme");
    actual === "light" ? temaOscuro() : temaClaro();
}

document.addEventListener("DOMContentLoaded", () => {
    const temaGuardado = localStorage.getItem("tema") || "light";
    temaGuardado === "dark" ? temaOscuro() : temaClaro();
});

function confirmarBaja(id, name, propertie) {
    Swal.fire({
        title: `Remove ${propertie}`,
        html: `Are you sure to remove the ${propertie} <strong>"${name}</strong>"?`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById(`formDelete-${id}`).submit();
        }
    });
}