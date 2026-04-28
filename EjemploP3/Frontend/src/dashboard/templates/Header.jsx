// 1. Cambiamos la importación al nuevo escudo
import Escudo3 from "/Escudo.png";

const Header = () => {
  return (
    <div className="flex bg-black justify-center items-center p-4 shadow-md border-b border-[#525252]">
      <div className="flex items-center space-x-4">
        
        {/* Contenedor de la imagen */}
        <div className="flex justify-center items-center">
          
          {/* OPCIÓN A: Fondo blanco suave para resaltar el logo oscuro (Recomendada para mantener identidad) */}
          <img src={Escudo3} alt="Logo USAC" className="w-20 hidden md:flex rounded-md bg-white p-1" />
          <img src={Escudo3} alt="Logo USAC" className="w-10 flex md:hidden rounded-md bg-white p-1" />

          {/* OPCIÓN B: Si prefieres que el logo negro se vuelva blanco, comenta las dos líneas de arriba y usa estas: */}
          {/* <img src={Escudo3} alt="Logo USAC" className="w-20 hidden md:flex invert" />
          <img src={Escudo3} alt="Logo USAC" className="w-10 flex md:hidden invert" /> */}
          
        </div>

        {/* Título adaptado a la paleta */}
        <h1 className="text-4xl md:text-7xl flex items-center">
          <span className="text-white font-bold">Proyecto</span>
          <span className="text-[#525252] font-bold ml-1">3</span>
        </h1>

      </div>
    </div>
  );
}

export default Header;