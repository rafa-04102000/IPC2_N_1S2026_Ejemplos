import { useState } from 'react';
import axios from 'axios';
import { sileo, Toaster } from "sileo";

import url from '../../Api/url';
import CuervoLoader from "./Loaders/CuervoLoader";

// Iconos para adornar la interfaz
import { FaInfoCircle, FaUserTie, FaLaptopCode, FaExclamationTriangle, FaDownload, FaFileAlt } from "react-icons/fa";

const Sistema = () => {
    const [isResetting, setIsResetting] = useState(false);

    // Función para manejar el reseteo del sistema (Sin alerta)
    const handleReset = async () => {
        setIsResetting(true);

        try {
            await axios.post(`${url}Config/resetear`);

            sileo.success({
                title: "Sistema Reseteado",
                description: "La base de datos se ha limpiado exitosamente.",
                fill: "black",
                styles: { title: "text-green-400", description: "text-green-300/80" },
                duration: 5000,
            });
        } catch (error) {
            console.error("Error al resetear el sistema:", error);
            sileo.error({
                title: "Error Fatal",
                description: "Hubo un problema al intentar comunicar con el servidor para resetear.",
                fill: "black",
                styles: { title: "text-red-400", description: "text-red-300/80" },
                duration: 5000,
            });
        } finally {
            setIsResetting(false);
        }
    };

    return (
        <>
            <Toaster position="bottom-right" />
            <div className="p-8 max-w-7xl mx-auto">
                <h2 className="text-3xl font-bold mb-8 text-black border-b border-[#525252] pb-2 flex items-center gap-3">
                    <FaInfoCircle className="text-[#525252]" />
                    Información del Sistema
                </h2>

                <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">

                    {/* COLUMNA IZQUIERDA: Información y Loader (Ocupa 2/3 del espacio) */}
                    <div className="lg:col-span-2 space-y-6">

                        {/* Tarjeta de Detalles del Proyecto */}
                        <div className="bg-white p-8 rounded-lg shadow-md border border-[#525252] relative overflow-hidden">
                            <h3 className="text-2xl font-bold text-black mb-4 flex items-center gap-2">
                                <FaLaptopCode className="text-[#525252]" />
                                Control de Clientes, Bancos, Pagos y Facturas
                            </h3>

                            <p className="text-gray-700 leading-relaxed mb-6 text-lg">
                                Este sistema corresponde a la <strong>implementación de referencia para el Proyecto 3</strong> de los alumnos del curso de Introducción a la Programación y Computación 2 (IPC2).
                            </p>
                            {/* <p className="text-gray-700 leading-relaxed mb-6">
                                Su propósito principal es servir como base comparativa y estándar de calificación. En base al funcionamiento, respuestas y validaciones de este sistema, se evaluarán y calificarán los proyectos entregados por los estudiantes para verificar que cumplan con los requerimientos establecidos en el enunciado oficial.
                            </p> */}

                            {/* Tarjeta del Autor */}
                            <div className="mt-8 bg-gray-50 border border-gray-200 p-4 rounded-md flex items-center gap-4">
                                <div className="bg-black text-white p-3 rounded-full">
                                    <FaUserTie className="text-2xl" />
                                </div>
                                <div>
                                    <p className="text-sm text-gray-500 uppercase font-bold tracking-wider">Desarrollado por</p>
                                    <p className="text-xl font-bold text-black">Tobías Rafael Zamora Santos</p>
                                    <p className="text-md text-[#525252]">Auxiliar de IPC2 - Sección N</p>
                                </div>
                            </div>
                        </div>

                        {/* Contenedor del CuervoLoader Ajustado */}
                        {/* Agregamos overflow-hidden, relative, y una altura controlada para evitar desbordes */}
                        <div className="bg-white rounded-lg shadow-md border border-[#525252] flex flex-col items-center justify-start overflow-hidden relative h-[320px] p-6">
                            <p className="text-gray-500 font-medium mb-2 text-sm tracking-widest uppercase z-10">
                                Sistema Operativo y Vigilando
                            </p>
                            {/* Un wrapper interno que centra el cuervo y recorta sus bordes visuales si se exceden */}
                            <div className="w-full flex-1 flex items-center justify-center relative">
                                <CuervoLoader />
                            </div>
                        </div>
                    </div>

                    {/* COLUMNA DERECHA: Acciones y Descargas (Ocupa 1/3 del espacio) */}
                    <div className="lg:col-span-1 space-y-6">

                        {/* ZONA DE PELIGRO: Reseteo */}
                        <div className="bg-red-50 p-6 rounded-lg shadow-md border border-red-200">
                            <h4 className="text-lg font-bold text-red-700 mb-2 flex items-center gap-2">
                                <FaExclamationTriangle />
                                Zona de Peligro
                            </h4>
                            <p className="text-sm text-red-600 mb-6">
                                Esta acción eliminará permanentemente todos los registros actuales de para iniciar una evaluación desde cero.
                                {/* Esta acción eliminará permanentemente todos los registros actuales de la base de datos para iniciar una evaluación desde cero. */}
                            </p>
                            <button
                                onClick={handleReset}
                                disabled={isResetting}
                                className={`cursor-pointer w-full py-3 px-4 rounded-md font-bold text-white transition-all shadow-sm flex justify-center items-center gap-2
                                ${isResetting ? 'bg-red-400 cursor-not-allowed' : 'bg-red-600 hover:bg-red-700 hover:shadow-md'}`}
                            >
                                <FaExclamationTriangle />
                                {isResetting ? 'Reseteando...' : 'Resetear Sistema'}
                            </button>
                        </div>

                        {/* ZONA DE DESCARGAS: Archivos de Prueba */}
                        <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252]">
                            <h4 className="text-lg font-bold text-black mb-4 flex items-center gap-2">
                                <FaDownload className="text-[#525252]" />
                                Archivos de Prueba
                            </h4>
                            <p className="text-sm text-gray-600 mb-4">
                                Archivos XML de entrada estándar para probar el sistema.
                                {/* Descarga los archivos XML de entrada estándar para probar el sistema. */}
                            </p>

                            {/* Fáciles */}
                            <div className="mb-6">
                                <h5 className="text-sm font-bold text-gray-800 mb-2 border-b pb-1">Nivel: Fáciles</h5>
                                <div className="space-y-2">
                                    <a href="/Faciles/config.xml" download className="flex items-center justify-between p-2 bg-gray-50 hover:bg-gray-100 rounded border border-gray-200 transition-colors group">
                                        <div className="flex items-center gap-2 text-sm text-gray-700 font-medium"><FaFileAlt className="text-gray-400" /> config.xml</div>
                                        <FaDownload className="text-gray-400 group-hover:text-black transition-colors" />
                                    </a>
                                    <a href="/Faciles/transac.xml" download className="flex items-center justify-between p-2 bg-gray-50 hover:bg-gray-100 rounded border border-gray-200 transition-colors group">
                                        <div className="flex items-center gap-2 text-sm text-gray-700 font-medium"><FaFileAlt className="text-gray-400" /> transac.xml</div>
                                        <FaDownload className="text-gray-400 group-hover:text-black transition-colors" />
                                    </a>
                                </div>
                            </div>

                            {/* Difíciles */}
                            <div>
                                <h5 className="text-sm font-bold text-gray-800 mb-2 border-b pb-1">Nivel: Difíciles</h5>
                                <div className="space-y-2">
                                    <a href="/Dificiles/config.xml" download className="flex items-center justify-between p-2 bg-gray-50 hover:bg-gray-100 rounded border border-gray-200 transition-colors group">
                                        <div className="flex items-center gap-2 text-sm text-gray-700 font-medium"><FaFileAlt className="text-gray-400" /> config.xml</div>
                                        <FaDownload className="text-gray-400 group-hover:text-black transition-colors" />
                                    </a>
                                    <a href="/Dificiles/transac.xml" download className="flex items-center justify-between p-2 bg-gray-50 hover:bg-gray-100 rounded border border-gray-200 transition-colors group">
                                        <div className="flex items-center gap-2 text-sm text-gray-700 font-medium"><FaFileAlt className="text-gray-400" /> transac.xml</div>
                                        <FaDownload className="text-gray-400 group-hover:text-black transition-colors" />
                                    </a>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </>
    );
}

export default Sistema;