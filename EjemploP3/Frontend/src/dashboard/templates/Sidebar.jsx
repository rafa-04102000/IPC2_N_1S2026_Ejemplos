import { Link } from 'react-router-dom';
import F1 from '/F1.jpg';

// Importamos íconos que concuerdan mejor con las opciones del menú
import { FaCog, FaExchangeAlt, FaSearch, FaChartBar } from "react-icons/fa";

const Sidebar = () => {
    const SIDEBAR_LINKS = [
        { id: 1, path: '/', name: 'Configuración', icon: FaCog },
        { id: 2, path: '/CargarTransacciones', name: 'Transacciones', icon: FaExchangeAlt },
        { id: 3, path: '/Consultas', name: 'Consultas', icon: FaSearch },
        { id: 4, path: '/Graficas', name: 'Gráficas', icon: FaChartBar },
    ];

    return (
        // Aplicamos el fondo negro (#000000)
        <div className='bg-black w-16 md:w-56 fixed left-0 top-0 z-10 h-screen pt-8 px-2'>
            {/* Logo principal */}
            <div className='mb-8 flex justify-center items-center'>
                <img src={F1} alt="cloud" className='w-28 hidden md:flex rounded-md'/>
                <img src={F1} alt="cloud" className='w-8 flex md:hidden rounded-md'/>
            </div>
            {/* Logo principal */}

            {/* Links en navegación */}
            <ul className='mt-6 space-y-2'>
                {SIDEBAR_LINKS.map((link, index) => (
                    <li 
                        key={index}
                        // Texto blanco y el hover usa el gris específico de tu paleta
                        className='text-white font-medium rounded-md py-2 px-5 hover:bg-[#525252] transition-colors duration-200'
                    >
                        <Link 
                            to={link.path}
                            className='flex justify-center md:justify-start items-center md:space-x-5'
                        >
                            {/* Renderizamos el icono como componente */}
                            <span className="text-xl"><link.icon /></span>
                            <span className='text-white text-xl hidden md:flex'>{link.name}</span>
                        </Link>
                    </li>
                ))}
            </ul>
            {/* Links en navegación */}
        </div>
    )
}

export default Sidebar;