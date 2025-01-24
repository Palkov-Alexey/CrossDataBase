import { defineConfig, externalizeDepsPlugin, defineViteConfig } from "electron-vite";
import { fileURLToPath, URL } from 'node:url';
import react from '@vitejs/plugin-react';
import { env } from 'process';
import { resolve } from 'path';

const target = //env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7290';

// https://vitejs.dev/config/
export default defineConfig({
    main: {
        plugins: [externalizeDepsPlugin()],
        build: {
            lib: {
                entry: `./electron/main/index.ts`
            },
            rollupOptions: {
                output: {
                    format: `es`
                }
            }
        }
    },
    preload: {
        plugins: [externalizeDepsPlugin()],
        build: {
            lib: {
                entry: `./electron/preload/index.ts`
            },
            rollupOptions: {
                output: {
                    format: `es`
                }
            }
        }
    },
    renderer: {
        plugins: [react({
            babel: {
                plugins: [["@babel/plugin-proposal-decorators", { "version": "2023-11" }]]
            },
        })],
        resolve: {
            alias: {
                '@': fileURLToPath(new URL('./src', import.meta.url)),
                '@renderer': resolve('src/')
            }
        },
        server: {
            proxy: {
                '^/api/.*': {
                    target,
                    secure: false
                }
            }
            //port: 5173
        },
        build: {
            rollupOptions: {
                input: {
                    index: resolve(__dirname, `index.html`)
                }
            }
        }
    }

})