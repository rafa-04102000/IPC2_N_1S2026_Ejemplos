import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), tailwindcss()],
  server: {
    proxy: {
      '/api': {
        // La URL de tu backend local de .NET
        target: 'https://localhost:7161',
        changeOrigin: true,
        // Ignora los errores de certificado HTTPS local de .NET
        secure: false, 
        // Nota: NO usamos rewrite aquí porque queremos que .NET reciba el "/api/..."
      }
    }
  }
})
