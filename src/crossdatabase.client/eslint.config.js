import js from '@eslint/js';
import stylistic from '@stylistic/eslint-plugin';
import stylisticJsx from '@stylistic/eslint-plugin-jsx';
import stylisticTs from '@stylistic/eslint-plugin-ts';
import importPlugin from 'eslint-plugin-import';
import importQuotes from 'eslint-plugin-import-quotes';
import reactHooks from 'eslint-plugin-react-hooks';
import reactRefresh from 'eslint-plugin-react-refresh';
import globals from 'globals';
import tslint from 'typescript-eslint';

export default tslint.config({ ignores: [`dist`, `obj`, `out`, `.vscode`, `.idea`, `node_modules`] },
    {
        extends: [js.configs.recommended,
            ...tslint.configs.recommended
        ],
        files: [`**/*.{ts,tsx,js}`],
        languageOptions: {
            ecmaVersion: 2020,
            globals: globals.browser
        },
        plugins: {
            'react-hooks': reactHooks,
            'react-refresh': reactRefresh,
            '@stylistic': stylistic,
            '@stylistic/ts': stylisticTs,
            '@stylistic/jsx': stylisticJsx,
            'import': importPlugin,
            'import-quotes': importQuotes,
        },
        rules: {
            ...reactHooks.configs.recommended.rules,
            'react-refresh/only-export-components': [
                `warn`,
                { allowConstantExport: true },
            ],
            '@typescript-eslint/explicit-function-return-type': `error`,
            'eqeqeq': `error`,
            'eol-last': `error`,
            'indent': [`error`, 4, { SwitchCase: 1 }],
            'brace-style': [`error`, `1tbs`, { allowSingleLine: true }],
            '@stylistic/semi': `error`,
            '@stylistic/quotes': [`warn`, `backtick`, { allowTemplateLiterals: true }],
            '@stylistic/arrow-spacing': `error`,
            '@stylistic/array-bracket-spacing': `error`,
            '@stylistic/object-curly-spacing': [`error`, `always`],
            '@stylistic/comma-spacing': `error`,
            '@stylistic/keyword-spacing': `error`,
            '@stylistic/space-before-blocks': `error`,
            '@stylistic/lines-between-class-members': `error`,
            '@stylistic/ts/padding-line-between-statements': [`error`, {
                "blankLine": `always`,
                "prev": `*`,
                "next": [
                    `block`,
                    `block-like`,
                    `break`,
                    `switch`,
                    `class`,
                    `return`,
                    `for`,
                    `if`,
                    `function`,
                    `while`,
                    `throw`,
                    `type`,
                    `enum`,
                    `interface`,
                    `export`
                ]
            },
            {
                "blankLine": `always`,
                "prev": [
                    `block`,
                    `block-like`,
                    `break`,
                    `switch`,
                    `class`,
                    `return`,
                    `for`,
                    `if`,
                    `function`,
                    `while`,
                    `throw`,
                    `type`,
                    `enum`,
                    `interface`,
                    `export`
                ],
                "next": `*`
            }],
            '@stylistic/ts/key-spacing': [`error`, { afterColon: true, beforeColon: false }],
            '@stylistic/ts/space-infix-ops': [`error`, { ignoreTypes: false }],
            '@stylistic/ts/type-annotation-spacing': `error`,
            'import/first': [`error`, `absolute-first`],
            'import/order': [`warn`, {
                groups: [`builtin`, `external`, `internal`, `parent`, `sibling`, `index`],
                'newlines-between': `never`,
                'alphabetize': {
                    'order': `asc`,
                    'caseInsensitive': true
                }
            }],
            'import-quotes/import-quotes': [`error`, `single`],
        },
    },
);
