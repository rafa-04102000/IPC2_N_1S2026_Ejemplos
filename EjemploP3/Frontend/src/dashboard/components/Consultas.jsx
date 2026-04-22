import { useState, useEffect } from 'react';
import axios from 'axios';
import { FaSearch, FaUserTie, FaMoneyBillWave, FaListAlt, FaUsers } from 'react-icons/fa';
import { sileo, Toaster } from "sileo";

import url from '../../Api/url';

const Consultas = () => {
    // Estados para la lista de clientes y la selección
    const [clientes, setClientes] = useState([]);
    const [selectedNit, setSelectedNit] = useState('');
    const [loadingClientes, setLoadingClientes] = useState(true);

    // Estados para la data del cliente específico
    const [clienteData, setClienteData] = useState(null);
    const [loadingDetalle, setLoadingDetalle] = useState(false);

    // 1. Cargar la lista de clientes al montar el componente
    useEffect(() => {
        const fetchClientes = async () => {
            try {
                const response = await axios.get(`${url}Consulta/clientes`);
                setClientes(response.data);
                setLoadingClientes(false);
            } catch (err) {
                console.error("Error al cargar clientes:", err);
                setLoadingClientes(false);
                sileo.error({
                    title: "Error de conexión",
                    description: "No se pudo cargar la lista de clientes.",
                    fill: "black",
                    styles: { title: "text-red-400", description: "text-red-300/80" },
                    duration: 5000,
                });
            }
        };

        fetchClientes();
    }, []);

    // 2. Función centralizada para buscar el detalle del cliente
    const fetchDetalleCliente = async (nitToSearch) => {
        if (!nitToSearch) return;

        setLoadingDetalle(true);
        setClienteData(null); // Limpiamos la data anterior

        try {
            const response = await axios.get(`${url}Consulta/cliente/${nitToSearch}`);
            setClienteData(response.data);
            
            sileo.success({
                title: "Consulta Exitosa",
                description: `Datos cargados correctamente.`,
                fill: "black",
                styles: { title: "text-green-400", description: "text-green-300/80" },
                duration: 4000,
            });
        } catch (err) {
            console.error("Error al buscar cliente:", err);
            sileo.error({
                title: "Error en la consulta",
                description: "Hubo un problema al buscar las transacciones.",
                fill: "black",
                styles: { title: "text-red-400", description: "text-red-300/80" },
                duration: 5000,
            });
        } finally {
            setLoadingDetalle(false);
        }
    };

    // Manejador del formulario (botón buscar)
    const handleBuscarSubmit = (e) => {
        e.preventDefault();
        if (!selectedNit) {
            sileo.error({
                title: "Atención",
                description: "Por favor selecciona un cliente.",
                fill: "black",
                styles: { title: "text-yellow-400", description: "text-yellow-300/80" },
                duration: 4000,
            });
            return;
        }
        fetchDetalleCliente(selectedNit);
    };

    // Manejador al hacer clic en un cliente de la lista lateral
    const handleSeleccionDesdeLista = (nit) => {
        setSelectedNit(nit); // Actualiza el select
        fetchDetalleCliente(nit); // Dispara la búsqueda automáticamente
    };

    return (
        <>
            <Toaster position="bottom-right" />
            {/* Aumentamos el max-w para dar espacio a las dos columnas */}
            <div className="p-8 max-w-7xl mx-auto">
                <h2 className="text-3xl font-bold mb-8 text-black border-b border-[#525252] pb-2">Panel de Consultas</h2>

                {/* Contenedor Grid Principal */}
                <div className="grid grid-cols-1 lg:grid-cols-12 gap-8">
                    
                    {/* COLUMNA IZQUIERDA: Directorio de Clientes (Ocupa 4 de 12 columnas) */}
                    <div className="lg:col-span-4 bg-white p-6 rounded-lg shadow-md border border-[#525252] h-fit">
                        <h3 className="text-xl font-bold text-black flex items-center gap-2 mb-4">
                            <FaUsers className="text-[#525252]" />
                            Directorio de Clientes
                        </h3>
                        
                        {/* Lista con scroll si hay muchos clientes */}
                        <div className="max-h-[600px] overflow-y-auto pr-2 space-y-2 custom-scrollbar">
                            {loadingClientes ? (
                                <p className="text-gray-500 text-center py-4">Cargando...</p>
                            ) : clientes.length === 0 ? (
                                <p className="text-gray-500 text-center py-4">No hay clientes registrados.</p>
                            ) : (
                                clientes.map((cliente) => (
                                    <button
                                        key={cliente.nit}
                                        onClick={() => handleSeleccionDesdeLista(cliente.nit)}
                                        className={`cursor-pointer w-full text-left p-3 rounded-md border transition-all duration-200
                                            ${selectedNit === cliente.nit 
                                                ? 'bg-[#525252] border-[#525252] text-white shadow-md' // Estilo activo
                                                : 'bg-gray-50 border-gray-200 hover:border-[#525252] hover:bg-gray-100 text-gray-800' // Estilo inactivo
                                            }`}
                                    >
                                        <p className={`font-bold ${selectedNit === cliente.nit ? 'text-white' : 'text-black'}`}>
                                            {cliente.nit}
                                        </p>
                                        <p className={`text-sm truncate ${selectedNit === cliente.nit ? 'text-gray-200' : 'text-gray-600'}`}>
                                            {cliente.nombre}
                                        </p>
                                    </button>
                                ))
                            )}
                        </div>
                    </div>

                    {/* COLUMNA DERECHA: Buscador y Resultados (Ocupa 8 de 12 columnas) */}
                    <div className="lg:col-span-8 space-y-8">
                        
                        {/* Tarjeta de Búsqueda (Select) */}
                        <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252]">
                            <p className="text-gray-600 mb-6">Selecciona un cliente del listado izquierdo o búscalo en el desplegable.</p>

                            <form onSubmit={handleBuscarSubmit} className="flex flex-col md:flex-row items-center gap-4">
                                <div className="w-full relative">
                                    <div className="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none">
                                        <FaUserTie className="text-gray-400" />
                                    </div>
                                    <select
                                        value={selectedNit}
                                        onChange={(e) => setSelectedNit(e.target.value)}
                                        disabled={loadingClientes}
                                        className="block w-full pl-10 pr-3 py-2 border border-gray-300 rounded-md text-gray-700 focus:outline-none focus:ring-2 focus:ring-[#525252] focus:border-transparent appearance-none bg-gray-50"
                                    >
                                        <option value="">
                                            {loadingClientes ? "Cargando clientes..." : "-- Seleccione un Cliente --"}
                                        </option>
                                        {clientes.map((cliente) => (
                                            <option key={cliente.nit} value={cliente.nit}>
                                                {cliente.nit} - {cliente.nombre}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <button
                                    type="submit"
                                    disabled={loadingDetalle || loadingClientes || !selectedNit}
                                    className={`cursor-pointer flex items-center justify-center gap-2 px-8 py-2 rounded-md text-white font-medium transition-colors w-full md:w-auto
                                    ${(loadingDetalle || !selectedNit) ? 'bg-gray-400 cursor-not-allowed' : 'bg-black hover:bg-[#525252]'}`}
                                >
                                    <FaSearch />
                                    {loadingDetalle ? 'Buscando...' : 'Consultar'}
                                </button>
                            </form>
                        </div>

                        {/* Área de Resultados (Estado de Cuenta) */}
                        {clienteData && (
                            <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252] animate-fade-in">
                                {/* Cabecera del Estado de Cuenta */}
                                <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-6 pb-4 border-b border-gray-200 gap-4">
                                    <div>
                                        <h3 className="text-2xl font-bold text-black flex items-center gap-2">
                                            <FaUserTie className="text-[#525252]" />
                                            {clienteData.cliente}
                                        </h3>
                                    </div>
                                    <div className="bg-gray-100 px-4 py-2 rounded-md border border-gray-300 flex items-center gap-3">
                                        <FaMoneyBillWave className="text-green-600 text-xl" />
                                        <div>
                                            <p className="text-xs text-gray-500 uppercase font-semibold">Saldo Actual</p>
                                            <p className="text-xl font-bold text-black">{clienteData.saldoActual}</p>
                                        </div>
                                    </div>
                                </div>

                                {/* Tabla de Transacciones */}
                                <div>
                                    <h4 className="text-lg font-bold text-gray-700 mb-4 flex items-center gap-2">
                                        <FaListAlt className="text-gray-500" />
                                        Historial de Transacciones
                                    </h4>
                                    
                                    <div className="overflow-x-auto border border-gray-200 rounded-md">
                                        <table className="min-w-full divide-y divide-gray-200">
                                            <thead className="bg-gray-50">
                                                <tr>
                                                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Fecha</th>
                                                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Cargo</th>
                                                    <th scope="col" className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Abono</th>
                                                </tr>
                                            </thead>
                                            <tbody className="bg-white divide-y divide-gray-200">
                                                {clienteData.transacciones && clienteData.transacciones.length > 0 ? (
                                                    clienteData.transacciones.map((tx, index) => (
                                                        <tr key={index} className="hover:bg-gray-50 transition-colors">
                                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900">{tx.fecha}</td>
                                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-red-600 font-medium">{tx.cargo || "-"}</td>
                                                            <td className="px-6 py-4 whitespace-nowrap text-sm text-green-600 font-medium">{tx.abono || "-"}</td>
                                                        </tr>
                                                    ))
                                                ) : (
                                                    <tr>
                                                        <td colSpan="3" className="px-6 py-8 text-center text-gray-500">
                                                            No hay transacciones registradas para este cliente.
                                                        </td>
                                                    </tr>
                                                )}
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        )}
                    </div>
                </div>
            </div>
        </>
    );
}

export default Consultas;