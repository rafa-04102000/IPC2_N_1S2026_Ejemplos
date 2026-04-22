import { useState, useEffect } from 'react';
import axios from 'axios';
import { sileo, Toaster } from "sileo";
import { FaCalendarAlt } from 'react-icons/fa';
import url from '../../Api/url';

// Importaciones necesarias de Chart.js
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
} from 'chart.js';
import { Bar } from 'react-chartjs-2';

// Registrar los componentes de Chart.js
ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

const Graficas = () => {
    // 1. Obtener fecha actual por defecto
    const fechaActual = new Date();
    const [mes, setMes] = useState(fechaActual.getMonth() + 1); // getMonth es 0-11, sumamos 1
    const [anio, setAnio] = useState(fechaActual.getFullYear());
    
    const [chartData, setChartData] = useState(null);
    const [loading, setLoading] = useState(false);

    // Paleta de colores para los bancos (puedes agregar más si tienes muchos bancos)
    const coloresBancos = [
        '#525252', // Tu gris oscuro
        '#ef4444', // Rojo
        '#3b82f6', // Azul
        '#10b981', // Verde
        '#f59e0b', // Amarillo/Naranja
        '#8b5cf6', // Morado
        '#774205', // Cafe
        '#db2777', // Rosa
        '#0ea5e9', // Cyan
        '#16a34a', // Verde Oscuro
    ];

    // 2. Efecto para consultar a la API cuando cambie el mes o el año
    useEffect(() => {
        const fetchDatosGrafica = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`${url}Consulta/ingresos-bancos?mes=${mes}&anio=${anio}`);
                const data = response.data;

                if (data.length === 0) {
                    setChartData(null);
                    sileo.error({
                        title: "Sin datos",
                        description: "No hay registros para la fecha seleccionada.",
                        fill: "black",
                        styles: { title: "text-yellow-400", description: "text-yellow-300/80" }
                    });
                    setLoading(false);
                    return;
                }

                // 3. TRANSFORMACIÓN DE DATOS PARA CHART.JS
                
                // A) Obtener períodos únicos ordenados por fechaParaOrden
                const periodosMap = new Map();
                data.forEach(item => {
                    if (!periodosMap.has(item.periodo)) {
                        periodosMap.set(item.periodo, item.fechaParaOrden);
                    }
                });
                // Ordenar cronológicamente
                const labelsOrdenados = Array.from(periodosMap.keys()).sort((a, b) => {
                    return new Date(periodosMap.get(a)) - new Date(periodosMap.get(b));
                });

                // B) Obtener lista de bancos únicos
                const bancosUnicos = [...new Set(data.map(item => item.banco))];

                // C) Crear los datasets agrupando totales por banco y período
                const datasets = bancosUnicos.map((banco, index) => {
                    const dataPorBanco = labelsOrdenados.map(periodo => {
                        // Buscar si el banco tiene un registro en este período
                        const registro = data.find(item => item.banco === banco && item.periodo === periodo);
                        return registro ? registro.total : 0; // Si no hay, es 0
                    });

                    return {
                        label: banco,
                        data: dataPorBanco,
                        backgroundColor: coloresBancos[index % coloresBancos.length],
                    };
                });

                // D) Actualizar el estado con el formato de Chart.js
                setChartData({
                    labels: labelsOrdenados,
                    datasets: datasets
                });

            } catch (error) {
                console.error("Error al cargar gráfica:", error);
                sileo.error({
                    title: "Error",
                    description: "No se pudieron cargar los datos de la gráfica.",
                    fill: "black",
                    styles: { title: "text-red-400", description: "text-red-300/80" }
                });
            } finally {
                setLoading(false);
            }
        };

        fetchDatosGrafica();
    }, [mes, anio]); // Se ejecuta cada vez que 'mes' o 'anio' cambian

    // Opciones de configuración visual para la gráfica
    const chartOptions = {
        responsive: true,
        plugins: {
            legend: {
                position: 'top',
            },
            title: {
                display: true,
                text: 'Comparativa de Ingresos por Banco (Últimos meses)',
                font: { size: 18 }
            },
        },
        scales: {
            y: {
                beginAtZero: true,
                title: {
                    display: true,
                    text: 'Total (Q)'
                }
            }
        }
    };

    return (
        <>
            <Toaster position="bottom-right" />
            <div className="p-8 max-w-6xl mx-auto">
                <h2 className="text-3xl font-bold mb-6 text-black border-b border-[#525252] pb-2">Gráficas de Ingresos</h2>

                {/* Filtros de Fecha */}
                <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252] mb-8">
                    <p className="text-gray-600 mb-4">Selecciona el mes y año de referencia. Se mostrará la información del mes seleccionado y los tres meses anteriores.</p>
                    
                    <div className="flex flex-col md:flex-row gap-4 items-center">
                        <div className="flex items-center gap-2 bg-gray-50 border border-gray-300 p-2 rounded-md">
                            <FaCalendarAlt className="text-[#525252]" />
                            <select 
                                value={mes} 
                                onChange={(e) => setMes(parseInt(e.target.value))}
                                className="bg-transparent outline-none text-gray-700"
                            >
                                <option value={1}>Enero</option>
                                <option value={2}>Febrero</option>
                                <option value={3}>Marzo</option>
                                <option value={4}>Abril</option>
                                <option value={5}>Mayo</option>
                                <option value={6}>Junio</option>
                                <option value={7}>Julio</option>
                                <option value={8}>Agosto</option>
                                <option value={9}>Septiembre</option>
                                <option value={10}>Octubre</option>
                                <option value={11}>Noviembre</option>
                                <option value={12}>Diciembre</option>
                            </select>
                        </div>

                        <div className="flex items-center gap-2 bg-gray-50 border border-gray-300 p-2 rounded-md">
                            <select 
                                value={anio} 
                                onChange={(e) => setAnio(parseInt(e.target.value))}
                                className="bg-transparent outline-none text-gray-700"
                            >
                                {/* Puedes generar estos dinámicamente, aquí pongo algunos de ejemplo */}
                                <option value={2023}>2023</option>
                                <option value={2024}>2024</option>
                                <option value={2025}>2025</option>
                                <option value={2026}>2026</option>
                                <option value={2027}>2027</option>
                            </select>
                        </div>
                    </div>
                </div>

                {/* Contenedor de la Gráfica */}
                <div className="bg-white p-6 rounded-lg shadow-md border border-[#525252] min-h-[400px] flex items-center justify-center">
                    {loading ? (
                        <p className="text-xl font-bold text-gray-400 animate-pulse">Cargando gráfica...</p>
                    ) : chartData ? (
                        <Bar data={chartData} options={chartOptions} />
                    ) : (
                        <p className="text-gray-500">No hay datos disponibles para graficar en este período.</p>
                    )}
                </div>
            </div>
        </>
    );
}

export default Graficas;