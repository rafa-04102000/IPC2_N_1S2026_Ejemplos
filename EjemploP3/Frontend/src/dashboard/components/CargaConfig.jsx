import { useState } from 'react';
import axios from 'axios';
import { FaUpload, FaDownload, FaFileCode } from 'react-icons/fa';
import { sileo, Toaster } from "sileo";

import url from '../../Api/url';

const CargaConfig = () => {
    // Estados para manejar el archivo, la respuesta y el estado de la petición
    const [file, setFile] = useState(null);
    const [responseXml, setResponseXml] = useState('');
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    // Maneja la selección del archivo
    const handleFileChange = (e) => {
        const selectedFile = e.target.files[0];
        setFile(selectedFile);
        // Limpiamos la respuesta y errores previos al seleccionar un nuevo archivo
        setResponseXml('');
        setError(null);
    };

    // Maneja el envío del archivo a la API
    const handleUpload = async (e) => {
        e.preventDefault();

        if (!file) {
            setError('Por favor, selecciona un archivo XML.');
            return;
        }

        setLoading(true);
        setError(null);

        // Preparamos el form-data tal como lo tienes en Postman
        const formData = new FormData();
        formData.append('archivo', file);

        try {
            // Asegúrate de que la URL y el puerto coincidan con tu backend
            const response = await axios.post(`${url}Config/Cargar`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            });

            // Guardamos la respuesta XML en el estado (Axios la suele parsear como string automáticamente)
            setResponseXml(response.data);

            sileo.success({
                title: "Archivo Cargado",
                description: "El archivo de configuración se ha cargado exitosamente.",
                fill: "black",
                styles: {
                    title: "text-green-400",
                    description: "text-green-300/80",
                },
                duration: 5000,
            });
        } catch (err) {
            console.error(err);
            setError('Hubo un error al conectar con la API. Verifica que tu backend esté en ejecución y tenga CORS habilitado.');
            sileo.error({
                title: "Error",
                description: "Hubo un error al cargar el archivo de configuración.",
                fill: "black",
                styles: {
                    title: "text-red-400",
                    description: "text-red-300/80",
                },
                duration: 5000,
            });
        } finally {
            setLoading(false);
        }
    };

    // Maneja la creación y descarga del archivo de respuesta
    const handleDownload = () => {
        if (!responseXml) return;

        // Creamos un Blob con el contenido XML
        const blob = new Blob([responseXml], { type: 'application/xml' });
        const url = URL.createObjectURL(blob);

        // Creamos un enlace temporal para forzar la descarga
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', 'respuestaConfig.xml'); // Nombre del archivo a descargar
        document.body.appendChild(link);
        link.click();

        // Limpiamos el DOM
        link.parentNode.removeChild(link);
        URL.revokeObjectURL(url);
    };

    return (
        <>
            <Toaster position="bottom-right" />
            <div className="p-8 max-w-4xl mx-auto">
                <h2 className="text-3xl font-bold mb-6 text-black">Carga de Configuración</h2>

                <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252]">
                    <p className="text-gray-600 mb-6">Selecciona tu archivo de configuración (.xml) para inicializar el sistema.</p>

                    {/* Formulario de Carga */}
                    <form onSubmit={handleUpload} className="flex flex-col md:flex-row items-center gap-4 mb-8">
                        <input
                            type="file"
                            accept=".xml" // Restringe a solo archivos XML
                            onChange={handleFileChange}
                            className="block w-full text-sm text-gray-500
                            file:mr-4 file:py-2 file:px-4
                            file:rounded-md file:border-0
                            file:text-sm file:font-semibold
                            file:bg-[#525252] file:text-white
                            hover:file:bg-black transition-colors"
                        />

                        <button
                            type="submit"
                            disabled={loading}
                            className={`cursor-pointer flex items-center justify-center gap-2 px-6 py-2 rounded-md text-white font-medium transition-colors w-full md:w-auto
                            ${loading || !file ? 'bg-gray-400 cursor-not-allowed' : 'bg-black hover:bg-[#525252]'}`}
                        >
                            <FaUpload />
                            {loading ? 'Cargando...' : 'Cargar'}
                        </button>
                    </form>

                    {/* Mensaje de Error */}
                    {error && (
                        <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded mb-6">
                            {error}
                        </div>
                    )}

                    {/* Área de Respuesta (Solo se muestra si hay respuesta exitosa) */}
                    {responseXml && (
                        <div className="mt-8 border-t border-[#525252] pt-6">
                            <div className="flex justify-between items-center mb-4">
                                <h3 className="text-xl font-bold text-black flex items-center gap-2">
                                    <FaFileCode className="text-[#525252]" />
                                    Respuesta del Servidor
                                </h3>

                                {/* Botón de Descarga */}
                                <button
                                    onClick={handleDownload}
                                    className="cursor-pointer flex items-center gap-2 bg-[#525252] hover:bg-black text-white px-4 py-2 rounded-md transition-colors"
                                >
                                    <FaDownload />
                                    Descargar XML
                                </button>
                            </div>

                            {/* Textarea de solo lectura para visualizar el XML */}
                            <textarea
                                readOnly
                                value={responseXml}
                                className="w-full h-64 p-4 font-mono text-sm bg-gray-50 text-black border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-[#525252]"
                            />
                        </div>
                    )}
                </div>
            </div>
        </>
    );
}

export default CargaConfig;