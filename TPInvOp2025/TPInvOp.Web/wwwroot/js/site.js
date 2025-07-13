const temaOscuro = () => {
    document.querySelector("body").setAttribute("data-bs-theme", "dark");
    document.querySelector("#d1-icon").setAttribute("class", "bi bi-sun-fill");
    document.querySelector("li").setAttribute("text-light")
}

const temaClaro = () => {
    document.querySelector("body").setAttribute("data-bs-theme", "light");
    document.querySelector("#d1-icon").setAttribute("class", "bi bi-moon-fill");
    document.querySelector("li").setAttribute("text-dark")
}

const cambiarTema = () => {
    document.querySelector("body").getAttribute("data-bs-theme") === "light" ?
        temaOscuro() : temaClaro();
}

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