import React from "react";
import tux from "/Tux.png";

const TuxLoader = () => {
  return (
    <>
      <style>{`
        .tux-walk {
          animation: tuxWalk 1.15s infinite ease-in-out;
          transform-origin: bottom center;
        }

        .tux-shadow {
          animation: tuxShadow 1.15s infinite ease-in-out;
        }

        .ground-dust {
          animation: dustMove 1.15s infinite linear;
        }

        .ground-dust.delay-1 {
          animation-delay: .25s;
        }

        .ground-dust.delay-2 {
          animation-delay: .55s;
        }

        @keyframes tuxWalk {
          0%, 100% {
            transform: translateX(-4px) translateY(0) rotate(-4deg) scaleY(1);
          }
          20% {
            transform: translateX(3px) translateY(-7px) rotate(4deg) scaleY(1.02);
          }
          40% {
            transform: translateX(8px) translateY(0) rotate(2deg) scaleY(.98);
          }
          60% {
            transform: translateX(3px) translateY(-6px) rotate(-3deg) scaleY(1.02);
          }
          80% {
            transform: translateX(-5px) translateY(0) rotate(-2deg) scaleY(.98);
          }
        }

        @keyframes tuxShadow {
          0%, 100% {
            transform: scaleX(1);
            opacity: .28;
          }
          50% {
            transform: scaleX(.7);
            opacity: .16;
          }
        }

        @keyframes dustMove {
          0% {
            transform: translateX(35px) translateY(0) scale(.6);
            opacity: 0;
          }
          25% {
            opacity: .35;
          }
          100% {
            transform: translateX(-55px) translateY(-12px) scale(1.1);
            opacity: 0;
          }
        }
      `}</style>

      <div className="relative w-[240px] h-[230px] flex items-center justify-center overflow-visible">
        {/* Partículas del suelo */}
        <span className="ground-dust absolute bottom-[34px] left-[120px] w-3 h-1 bg-black/40 rounded-full blur-[1px]" />
        <span className="ground-dust delay-1 absolute bottom-[28px] left-[135px] w-5 h-1 bg-black/30 rounded-full blur-[1px]" />
        <span className="ground-dust delay-2 absolute bottom-[39px] left-[110px] w-2 h-2 bg-black/25 rounded-full blur-[1px]" />

        {/* Sombra */}
        <div className="tux-shadow absolute bottom-[24px] w-[135px] h-[24px] bg-black/40 rounded-full blur-sm" />

        {/* Tux */}
        <img
          src={tux}
          alt="Tux Linux"
          className="tux-walk relative z-10 w-[180px] h-auto select-none pointer-events-none"
        />
      </div>
    </>
  );
};

export default TuxLoader;