import { Link } from 'react-router-dom';
// 1. Cambiamos la importación al nuevo archivo
import Escudo from '/Tux.png';

// Importamos íconos que concuerdan mejor con las opciones del menú
import { FaCog, FaExchangeAlt, FaSearch, FaChartBar, FaInfoCircle } from "react-icons/fa";

const Sidebar = () => {
    const SIDEBAR_LINKS = [
        { id: 1, path: '/', name: 'Configuración', icon: FaCog },
        { id: 2, path: '/CargarTransacciones', name: 'Transacciones', icon: FaExchangeAlt },
        { id: 3, path: '/Consultas', name: 'Consultas', icon: FaSearch },
        { id: 4, path: '/Graficas', name: 'Gráficas', icon: FaChartBar },
        { id: 5, path: '/Sistema', name: 'Sistema', icon: FaInfoCircle }, 
    ];

    return (
        // Aplicamos el fondo negro (#000000)
        <div className='bg-black w-16 md:w-56 fixed left-0 top-0 z-10 h-screen pt-8 px-2'>
            {/* Logo principal */}
            <div className='mb-8 flex justify-center items-center'>
                {/* TÉCNICA A: Contenedor claro. Agregamos 'bg-white' y un padding 'p-2' para que actúe como un marco. */}
                <img src={Escudo} alt="Logo USAC" className='w-45 hidden md:flex rounded-lg bg-white shadow-md'/>
                <img src={Escudo} alt="Logo USAC" className='w-10 flex md:hidden rounded-lg bg-white p-1'/>
            </div>
            {/* Logo principal */}

            {/* Links en navegación */}
            <ul className='mt-6 space-y-2'>
                {SIDEBAR_LINKS.map((link, index) => (
                    <li 
                        key={index}
                        className='text-white font-medium rounded-md py-2 px-5 hover:bg-[#525252] transition-colors duration-200'
                    >
                        <Link 
                            to={link.path}
                            className='flex justify-center md:justify-start items-center md:space-x-5'
                        >
                            <span className="text-xl"><link.icon /></span>
                            <span className='text-white text-xl hidden md:flex text-left'>{link.name}</span>
                        </Link>
                    </li>
                ))}
            </ul>
            {/* Links en navegación */}
        </div>
    )
}

export default Sidebar;