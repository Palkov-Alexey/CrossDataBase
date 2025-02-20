import { defineConfig, externalizeDepsPlugin } from "electron-vite";
import react from '@vitejs/plugin-react';
import { env } from 'process';

const target = //env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7290';

// https://vitejs.dev/config/
export default defineConfig({
    main: {
        plugins: [externalizeDepsPlugin()],
        build: {
            lib: {
                entry: `./electron/main/index.ts`
            }
        }
    },
    preload: {
        plugins: [externalizeDepsPlugin()],
        build: {
            lib: {
                entry: `./electron/preload/index.ts`
            }
        }
    },
    renderer: {
        plugins: [react({
            babel: {
                plugins: [["@babel/plugin-proposal-decorators", { "version": "2023-11" }]]
            },
        })],
        server: {
            proxy: {
                '^/api/.*': {
                    target,
                    secure: false
                }
            },
            port: 5173
        },
        root: `./`,
        build: {
            outDir: `dist`,
            rollupOptions: {
                input: {
                    index: `index.html`
                }
            }
        }
    }
})