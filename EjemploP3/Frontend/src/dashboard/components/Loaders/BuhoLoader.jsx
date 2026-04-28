import React from 'react';

const BuhoLoader = () => {
  return (
    <div className="owl-wrapper">
      <style>{`
        /* Contenedores principales */
        .owl-wrapper .main {
          position: relative;
          width: 30vmax;
          height: 30vmax;
          display: flex;
          justify-content: center;
          align-items: center;
          z-index: 10;
        }

        .owl-wrapper .owl {
          position: relative;
          width: 7.5vmax;
          height: 10vmax;
          animation: float 6s ease-in-out infinite;
        }

        /* Sombra */
        .owl-wrapper .owl::before {
          content: "";
          position: absolute;
          bottom: -2vmax;
          left: 50%;
          transform: translateX(-50%);
          width: 9vmax;
          height: 0.75vmax;
          background-color: #00000020;
          border-radius: 50%;
          z-index: -10;
          animation: shadow-bob 6s ease-in-out infinite;
        }

        /* Cuerpo */
        .owl-wrapper .owl__body {
          position: absolute;
          bottom: 1.5vmax;
          left: 50%;
          transform: translateX(-50%);
          width: 7vmax;
          height: 7vmax;
          background-color: #8c6d52;
          border-radius: 50% 50% 45% 45%;
          z-index: 2;
        }

        /* Parche del Vientre */
        .owl-wrapper .owl__body::before {
          content: "";
          position: absolute;
          bottom: 0.25vmax;
          left: 50%;
          transform: translateX(-50%);
          width: 4.5vmax;
          height: 4vmax;
          background-color: #c9b7a8;
          border-radius: 50% 50% 40% 40%;
        }

        /* Patrón de plumas */
        .owl-wrapper .owl__body::after {
          content: "v v v";
          position: absolute;
          bottom: 1.5vmax;
          left: 50%;
          transform: translateX(-50%);
          font-size: 0.75vmax;
          font-weight: bold;
          color: #8c6d5299;
          font-family: "Courier New", Courier, monospace;
          line-height: 0.8;
          letter-spacing: 0.25vmax;
        }

        /* Cabeza */
        .owl-wrapper .owl__head {
          position: absolute;
          top: 0;
          left: 50%;
          transform-origin: bottom center;
          width: 7.5vmax;
          height: 6.5vmax;
          background-color: #a58467;
          border-radius: 50%;
          z-index: 3;
          animation: head-tilt 6s ease-in-out infinite;
        }

        /* Orejas */
        .owl-wrapper .owl__tuft {
          position: absolute;
          top: -0.5vmax;
          width: 1.5vmax;
          height: 2vmax;
          background-color: #8c6d52;
          z-index: -1;
          animation: tuft-wiggle 6s ease-in-out infinite;
        }
        .owl-wrapper .owl__tuft--left {
          left: 0.5vmax;
          border-radius: 70% 30% 0 0;
          transform: rotate(-10deg);
        }
        .owl-wrapper .owl__tuft--right {
          right: 0.5vmax;
          border-radius: 30% 70% 0 0;
          transform: rotate(10deg);
          animation-delay: -0.2s;
        }

        /* Ojos */
        .owl-wrapper .owl__eye {
          position: absolute;
          top: 1.25vmax;
          width: 2.5vmax;
          height: 2.5vmax;
          background-color: #fff;
          border-radius: 50%;
          border: 0.25vmax solid #8c6d52;
          overflow: hidden;
          animation: blink 6s linear infinite;
        }
        .owl-wrapper .owl__eye::after {
          content: "";
          position: absolute;
          top: 50%;
          left: 50%;
          transform: translate(-50%, -50%);
          width: 1.25vmax;
          height: 1.25vmax;
          background-color: #2c2c2c;
          border-radius: 50%;
          animation: pupil-move 6s ease-in-out infinite;
        }
        .owl-wrapper .owl__eye--left { left: 0.75vmax; }
        .owl-wrapper .owl__eye--right { right: 0.75vmax; }

        /* Pico */
        .owl-wrapper .owl__beak {
          position: absolute;
          top: 3.5vmax;
          left: 50%;
          transform: translateX(-50%);
          width: 0;
          height: 0;
          border-left: 0.75vmax solid transparent;
          border-right: 0.75vmax solid transparent;
          border-top: 1vmax solid #f2b705;
        }

        /* Alas */
        .owl-wrapper .owl__wing {
          position: absolute;
          top: 2.5vmax;
          width: 4vmax;
          height: 6vmax;
          background-color: #a58467;
          border-radius: 80% 10% 80% 10%;
          z-index: 1;
        }
        .owl-wrapper .owl__wing--left {
          left: -1vmax;
          transform-origin: top right;
          animation: flap-left 6s ease-in-out infinite;
        }
        .owl-wrapper .owl__wing--right {
          right: -1vmax;
          transform-origin: top left;
          border-radius: 10% 80% 10% 80%;
          animation: flap-right 6s ease-in-out infinite;
        }

        /* Patitas */
        .owl-wrapper .owl__foot {
          position: absolute;
          bottom: 1vmax;
          width: 1vmax;
          height: 0.75vmax;
          background-color: #f2b705;
          border-radius: 40% 40% 50% 50%;
          z-index: 4;
          animation: dangle 3s ease-in-out infinite;
        }
        .owl-wrapper .owl__foot--left { left: 2vmax; }
        .owl-wrapper .owl__foot--right { right: 2vmax; animation-delay: -1.5s; }

        /* Nubes */
        .owl-wrapper .cloud {
          position: absolute;
          width: 7.5vmax;
          height: 2.5vmax;
          background-color: #ffffff;
          border-radius: 2.5vmax;
          opacity: 0.8;
          animation: cloud-drift linear infinite;
        }
        .owl-wrapper .cloud::before,
        .owl-wrapper .cloud::after {
          content: "";
          position: absolute;
          background-color: #ffffff;
          border-radius: 50%;
        }
        .owl-wrapper .cloud::before {
          width: 4vmax; height: 4vmax; top: -2vmax; left: 1vmax;
        }
        .owl-wrapper .cloud::after {
          width: 3vmax; height: 3vmax; top: -1vmax; right: 0.5vmax;
        }
        .owl-wrapper .cloud--1 { top: 20%; animation-duration: 40s; }
        .owl-wrapper .cloud--2 { top: 50%; transform: scale(0.7); animation-duration: 60s; animation-delay: -20s; }

        /* Animaciones */
        @keyframes float { 0%, 100% { transform: translateY(0); } 50% { transform: translateY(-2vmax); } }
        @keyframes shadow-bob { 0%, 100% { transform: translateX(-50%) scale(1); opacity: 1; } 50% { transform: translateX(-50%) scale(0.7); opacity: 0.5; } }
        @keyframes flap-left { 0%, 100% { transform: rotate(10deg); } 50% { transform: rotate(-25deg); } }
        @keyframes flap-right { 0%, 100% { transform: rotate(-10deg); } 50% { transform: rotate(25deg); } }
        @keyframes blink { 0%, 93%, 96%, 100% { transform: scaleY(1); } 95% { transform: scaleY(0.1); } }
        @keyframes pupil-move { 0%, 30% { transform: translate(-50%, -50%); } 40%, 60% { transform: translate(-80%, -50%); } 70%, 90% { transform: translate(-20%, -50%); } 100% { transform: translate(-50%, -50%); } }
        @keyframes dangle { 0%, 100% { transform: rotate(5deg); } 50% { transform: rotate(-10deg); } }
        @keyframes head-tilt { 0%, 100% { transform: translateX(-50%) rotate(0deg); } 20%, 30% { transform: translateX(-50%) rotate(-8deg); } 70%, 80% { transform: translateX(-50%) rotate(8deg); } }
        @keyframes tuft-wiggle { 0%, 100% { transform: translateY(0); } 50% { transform: translateY(-0.15vmax); } }
        @keyframes cloud-drift { from { left: -12.5vmax; } to { left: 110%; } }
      `}</style>

      <div>
        <div className="cloud cloud--1" />
        <div className="cloud cloud--2" />
        <div className="main">
          <div className="owl">
            <div className="owl__head">
              <div className="owl__tuft owl__tuft--left" />
              <div className="owl__tuft owl__tuft--right" />
              <div className="owl__eye owl__eye--left" />
              <div className="owl__eye owl__eye--right" />
              <div className="owl__beak" />
            </div>
            <div className="owl__body" />
            <div className="owl__wing owl__wing--left" />
            <div className="owl__wing owl__wing--right" />
            <div className="owl__foot owl__foot--left" />
            <div className="owl__foot owl__foot--right" />
          </div>
        </div>
      </div>
    </div>
  );
};

export default BuhoLoader;