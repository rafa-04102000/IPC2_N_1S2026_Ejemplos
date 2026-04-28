import React from 'react';

const HeladoLoader = () => {
  return (
    <>
      <style>{`
        /* Estilos de la paleta: Gradiente y animación */
        .popsicle-loader {
          background: #f0744f;
          background-image: linear-gradient(
            0deg,
            #f63a99 25%,
            #30dcf6 20%,
            #30dcf6 20%,
            #668c92 50%,
            #85782a 40%,
            #f2d200 50%,
            #f2d200 75%,
            #70ca5c 75%
          );
          background-position: 0px 0px;
          background-size: auto 175px;
          background-repeat: repeat-y;
          animation: colorShift 2s linear infinite;
        }

        /* Reflejo de luz (brillo blanco a la izquierda) */
        .popsicle-loader::before {
          content: "";
          position: absolute;
          left: 10px;
          bottom: 15px;
          width: 15px;
          height: 100px;
          border-radius: 50px;
          background: rgba(255, 255, 255, 0.5);
        }

        /* Palito de madera con sombra interior */
        .popsicle-loader::after {
          content: "";
          position: absolute;
          left: 50%;
          top: 100%;
          transform: translate(-50%, 0);
          box-shadow: inset 0 15px 2px rgba(0, 0, 0, 0.25);
          width: 32px;
          height: 45px;
          background: #534b44;
          border-radius: 0 0 12px 12px;
        }

        /* Animación para que el gradiente suba infinitamente */
        @keyframes colorShift {
          to {
            background-position: 0 175px;
          }
        }
      `}</style>

      {/* Contenedor principal con Tailwind */}
      <div className="relative w-[100px] h-[150px] rounded-t-[55px] rounded-b-[10px] popsicle-loader" />
    </>
  );
};

export default HeladoLoader;