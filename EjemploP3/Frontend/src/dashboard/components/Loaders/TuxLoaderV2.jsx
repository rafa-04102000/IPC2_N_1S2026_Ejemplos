import React from "react";

const TuxLoader = () => {
  return (
    <>
      <style>{`
        .tux-body {
          animation: bodyWalk 1s infinite ease-in-out;
          transform-origin: 50% 85%;
        }

        .left-foot {
          animation: leftStep 1s infinite ease-in-out;
          transform-origin: 35% 90%;
        }

        .right-foot {
          animation: rightStep 1s infinite ease-in-out;
          transform-origin: 65% 90%;
        }

        .left-arm {
          animation: leftArm 1s infinite ease-in-out;
          transform-origin: 35% 55%;
        }

        .right-arm {
          animation: rightArm 1s infinite ease-in-out;
          transform-origin: 65% 55%;
        }

        .tux-shadow {
          animation: shadowPulse 1s infinite ease-in-out;
        }

        .dust {
          animation: dustMove 1s infinite linear;
        }

        .dust-2 {
          animation-delay: .35s;
        }

        @keyframes bodyWalk {
          0%, 100% { transform: translateY(0) rotate(-3deg); }
          25% { transform: translateY(-7px) rotate(3deg); }
          50% { transform: translateY(0) rotate(2deg); }
          75% { transform: translateY(-6px) rotate(-3deg); }
        }

        @keyframes leftStep {
          0%, 100% { transform: translateY(0) rotate(-8deg); }
          50% { transform: translateY(-12px) translateX(8px) rotate(18deg); }
        }

        @keyframes rightStep {
          0%, 100% { transform: translateY(-10px) translateX(-6px) rotate(-15deg); }
          50% { transform: translateY(0) rotate(8deg); }
        }

        @keyframes leftArm {
          0%, 100% { transform: rotate(8deg); }
          50% { transform: rotate(-10deg); }
        }

        @keyframes rightArm {
          0%, 100% { transform: rotate(-8deg); }
          50% { transform: rotate(10deg); }
        }

        @keyframes shadowPulse {
          0%, 100% { transform: scaleX(1); opacity: .25; }
          50% { transform: scaleX(.72); opacity: .12; }
        }

        @keyframes dustMove {
          0% { transform: translateX(35px) translateY(0); opacity: 0; }
          30% { opacity: .35; }
          100% { transform: translateX(-45px) translateY(-10px); opacity: 0; }
        }
      `}</style>

      <div className="relative w-[180px] h-[180px] flex items-center justify-center">
<svg
  viewBox="0 0 180 180"
  className="w-[120px] h-[120px] overflow-visible"
  xmlns="http://www.w3.org/2000/svg"
>
  {/* Sombra */}
  <ellipse
    className="tux-shadow"
    cx="90"
    cy="160"
    rx="42"
    ry="8"
    fill="#000"
    opacity=".18"
  />

  {/* Pies */}
  <g className="left-foot">
    <path
      d="M62 137 C48 139, 42 151, 53 158 C65 165, 78 156, 75 145 C73 139, 68 136, 62 137Z"
      fill="#FFD21A"
      stroke="#050505"
      strokeWidth="4"
    />
  </g>

  <g className="right-foot">
    <path
      d="M118 137 C132 139, 138 151, 127 158 C115 165, 102 156, 105 145 C107 139, 112 136, 118 137Z"
      fill="#FFD21A"
      stroke="#050505"
      strokeWidth="4"
    />
  </g>

  {/* Cuerpo */}
  <g className="tux-body">
    {/* Cuerpo negro compacto */}
    <path
      d="M90 28
         C62 28, 48 52, 49 85
         C50 124, 65 150, 90 150
         C115 150, 130 124, 131 85
         C132 52, 118 28, 90 28Z"
      fill="#050505"
    />

    {/* Pechito blanco */}
    <path
      d="M90 82
         C74 82, 65 101, 67 124
         C69 144, 79 153, 90 153
         C101 153, 111 144, 113 124
         C115 101, 106 82, 90 82Z"
      fill="#ffffff"
      stroke="#d1d5db"
      strokeWidth="3"
    />

    {/* Alitas laterales */}
    <path
      className="left-arm"
      d="M57 84 C50 99, 51 116, 59 127"
      fill="none"
      stroke="#6b7280"
      strokeWidth="4"
      strokeLinecap="round"
    />

    <path
      className="right-arm"
      d="M123 84 C130 99, 129 116, 121 127"
      fill="none"
      stroke="#6b7280"
      strokeWidth="4"
      strokeLinecap="round"
    />

    {/* Ojos grandes estilo tierno */}
    <circle cx="74" cy="62" r="15" fill="#ffffff" />
    <circle cx="106" cy="62" r="15" fill="#ffffff" />

    <circle cx="75" cy="64" r="8" fill="#050505" />
    <circle cx="105" cy="64" r="8" fill="#050505" />

    <circle cx="70" cy="58" r="4" fill="#ffffff" />
    <circle cx="100" cy="58" r="4" fill="#ffffff" />

    {/* Pico pequeño */}
    <path
      d="M76 79 C84 71, 96 71, 104 79 C96 86, 84 86, 76 79Z"
      fill="#FFD21A"
      stroke="#050505"
      strokeWidth="3"
    />

    <path
      d="M77 80 C85 84, 95 84, 103 80"
      fill="none"
      stroke="#050505"
      strokeWidth="2.5"
      strokeLinecap="round"
    />

    {/* Brillos */}
    <ellipse
      cx="111"
      cy="38"
      rx="4"
      ry="10"
      fill="#9ca3af"
      opacity=".7"
      transform="rotate(-35 111 38)"
    />

    <circle cx="120" cy="50" r="3" fill="#9ca3af" opacity=".7" />
  </g>

  {/* Partículas */}
  <ellipse className="dust" cx="110" cy="158" rx="8" ry="2" fill="#d1d5db" />
  <ellipse className="dust dust-2" cx="125" cy="163" rx="6" ry="2" fill="#d1d5db" />
</svg>
      </div>
    </>
  );
};

export default TuxLoader;