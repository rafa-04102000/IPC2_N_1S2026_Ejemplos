import F2 from "/F2.jpg";

const Header = () => {
  return (
    // Cambiamos el fondo rojo por negro (bg-black) y añadimos un borde gris inferior opcional para separar del contenido
    <div className="flex bg-black justify-center items-center p-4 shadow-md border-b border-[#525252]">
      <div className="flex items-center space-x-4">
        
        {/* Contenedor de la imagen F1 */}
        <div className="flex justify-center items-center">
          {/* Usamos la variable F2 importada. Le agregué un pequeño margen y borde redondeado opcional */}
          <img src={F2} alt="Logo F2" className="w-20 hidden md:flex rounded-md" />
          <img src={F2} alt="Logo F2" className="w-10 flex md:hidden rounded-md" />
        </div>

        {/* Título adaptado a la paleta */}
        <h1 className="text-4xl md:text-7xl flex">
          <span className="text-white font-bold">Proyecto</span>
          {/* Usamos el color gris exacto para el número 3 */}
          <span className="text-[#525252] font-bold ml-1">3</span>
        </h1>

      </div>
    </div>
  );
}

export default Header;