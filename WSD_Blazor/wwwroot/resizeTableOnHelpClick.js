function resizeTable(b, i) {

    const table = document.querySelectorAll(".tableContainer")[i];

    const className = i == 0 ? "smallHome" : "smallProcess"
    

    if (b) {
        table.classList.add(className)
  
    } else {
  
        table.classList.remove(className)
    }
}