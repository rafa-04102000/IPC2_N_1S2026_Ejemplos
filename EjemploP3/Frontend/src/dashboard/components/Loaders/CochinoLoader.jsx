import React from 'react';

const CochinoLoader = () => {
  return (
    <div className="piggy-container">
      <style>{`
        /* Contenedor principal */
        .piggy-container .piggy-wrapper {
          position: relative;
          width: 350px;
          height: 350px;
          display: block;
          margin: 0 auto;
          margin-top: 0px;
        }

        /* Envoltorio del cerdito (Animación temblor) */
        .piggy-container .piggy-wrap {
          position: absolute;
          top: 0;
          left: 0;
          z-index: 10;
          width: 100%;
          height: 100%;
          transform-origin: bottom center;
          animation: trembling 5s linear infinite;
        }

        /* Cuerpo del cerdito */
        .piggy-container .piggy {
          position: absolute;
          bottom: 40px;
          left: 50%;
          margin-left: -160px;
          width: 270px;
          height: 200px;
          display: block;
          border-radius: 100px;
          background-color: #d88fa0;
        }
        .piggy-container .piggy:before {
          position: absolute;
          content: '';
          top: -25px;
          left: 55px;
          width: 60px;
          height: 60px;
          display: block;
          border-top-right-radius: 60px;
          background-color: #cb6980;
          z-index: -1;
        }

        /* Nariz */
        .piggy-container .nose {
          position: absolute;
          top: 80px;
          left: -25px;
          width: 40px;
          height: 60px;
          display: block;
          background-color: #d88fa0;
          z-index: 1;
          border-radius: 4px;
        }

        /* Boca */
        .piggy-container .mouth {
          position: absolute;
          top: 95px;
          left: -15px;
          width: 0;
          height: 0;
          z-index: 8;
          display: block;
          border-bottom: 60px solid #d88fa0;
          border-left: 20px solid transparent;
          border-right: 20px solid transparent;
          border-radius: 4px;
        }

        /* Oreja */
        .piggy-container .ear {
          position: absolute;
          top: -35px;
          left: 70px;
          width: 45px;
          height: 40px;
          display: block;
          border-top-right-radius: 60px;
          background-color: #d88fa0;
          z-index: 1;
        }

        /* Cola */
        .piggy-container .tail {
          position: absolute;
          left: 254px;
          top: 125px;
        }
        .piggy-container .tail span {
          position: absolute;
          left: 0;
          top: 0;
          width: 20px;
          height: 5px;
          transform: rotate(30deg);
          background-color: #d88fa0;
        }
        .piggy-container .tail span:nth-child(2) {
          left: 3px;
          top: -38px;
          width: 50px;
          height: 50px;
          transform: rotate(-20deg);
          background-color: transparent;
          border-radius: 50%;
          border-width: 5px;
          border-style: solid;
          border-color: transparent #d88fa0 #d88fa0 transparent;
        }
        .piggy-container .tail span:nth-child(3) {
          left: 22px;
          top: -36px;
          width: 30px;
          height: 30px;
          transform: rotate(-40deg);
          background-color: transparent;
          border-radius: 50%;
          border-width: 5px;
          border-style: solid;
          border-color: #d88fa0 transparent transparent #d88fa0;
        }
        .piggy-container .tail span:nth-child(4) {
          left: 7px;
          top: -66px;
          width: 60px;
          height: 60px;
          transform: rotate(-40deg);
          background-color: transparent;
          border-radius: 50%;
          border-width: 5px;
          border-style: solid;
          border-color: transparent transparent #d88fa0 transparent;
        }

        /* Ojo */
        .piggy-container .eye {
          position: absolute;
          left: 35px;
          top: 75px;
          width: 30px;
          height: 30px;
          transform: rotate(45deg);
          border-radius: 50%;
          border-width: 4px;
          border-style: solid;
          border-color: #555 transparent transparent #555;
          animation: blink 5s linear infinite;
        }

        /* Ranura para la moneda */
        .piggy-container .hole {
          position: absolute;
          left: 121px;
          top: 0;
          width: 60px;
          height: 5px;
          background-color: #555;
          border-bottom-left-radius: 5px;
          border-bottom-right-radius: 5px;
        }

        /* Envoltorio de la moneda */
        .piggy-container .coin-wrap {
          position: absolute;
          top: 0;
          left: -8px;
          z-index: 9;
          width: 100%;
          height: 100%;
          opacity: 0;
          transform-origin: bottom center;
          animation: trembling 5s linear infinite, moveCoin 5s linear infinite;
        }

        /* Moneda */
        .piggy-container .coin {
          position: absolute;
          top: 110px;
          left: 143px;
          z-index: 9;
          width: 61.5px;
          height: 61.5px;
          border-radius: 50%;
          border: 6px solid #e67e22;
          background-color: #f39c12;
          text-align: center;
          line-height: 68px; /* Ajustado para que el $ se centre mejor visualmente */
          font-size: 45px;
          font-weight: 500;
          color: rgba(32, 32, 32, 0.5);
          box-shadow: inset 0 0 4px #777;
          display: flex;
          justify-content: center;
          align-items: center;
        }

        /* Patas */
        .piggy-container .legs {
          position: absolute;
          bottom: 14px;
          left: 96px;
          width: 40px;
          height: 60px;
          display: block;
          background-color: #cb6980;
          border-radius: 3px;
          z-index: 1;
        }
        .piggy-container .legs:after {
          position: absolute;
          content: '';
          bottom: 0;
          left: 0;
          width: 30px;
          height: 12px;
          display: block;
          background-color: #d88fa0;
          border-bottom-left-radius: 3px;
          border-top-right-radius: 3px;
          z-index: 1;
        }
        .piggy-container .legs.back {
          left: 206px;
        }

        /* Animaciones */
        @keyframes trembling {
          0%, 19%, 22%, 24%, 26%, 28%, 30%, 61%, 100% { transform: scale(1); }
          21%, 23%, 25%, 27%, 29% { transform: scale(0.99); }
          60% { transform: scale(0.95); }
        }

        @keyframes blink {
          0%, 19%, 61%, 100% { border-color: #555 transparent transparent #555; }
          20%, 60% { border-color: transparent #555 #555 transparent; }
        }

        @keyframes moveCoin {
          0%, 19% { opacity: 0; top: 0; }
          19.1%, 20% { opacity: 1; top: 0; }
          21%, 22% { top: -7px; opacity: 1; }
          23%, 24% { top: -14px; opacity: 1; }
          25%, 26% { top: -21px; opacity: 1; }
          27%, 28% { top: -28px; opacity: 1; }
          29%, 30%, 60% { top: -35px; opacity: 1; }
          66% { top: -220px; opacity: 1; }
          67% { top: -220px; opacity: 0; }
          99%, 100% { top: 0; opacity: 0; }
        }
      `}</style>

      <div className="piggy-wrapper">
        <div className="piggy-wrap">
          <div className="piggy">
            <div className="nose" />
            <div className="mouth" />
            <div className="ear" />
            <div className="tail">
              <span />
              <span />
              <span />
              <span />
            </div>
            <div className="eye" />
            <div className="hole" />
          </div>
        </div>
        <div className="coin-wrap">
          <div className="coin">$</div>
        </div>
        <div className="legs" />
        <div className="legs back" />
      </div>
    </div>
  );
}

export default CochinoLoader;