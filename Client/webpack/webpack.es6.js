const path = require('path');
const RemovePlugin = require('remove-files-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer')
    .BundleAnalyzerPlugin;

const ROOT = path.resolve(__dirname, '../');
const BUILD_DIR = path.resolve(ROOT, '../wwwroot/ui');
const JS_DIR = path.resolve(ROOT, 'Scripts');
const CSS_DIR = path.resolve(ROOT, 'Styles');
const ES6_DIR = path.resolve(ROOT, 'es6');

const common = require('./webpack.common.js');
const { merge } = require('webpack-merge');

module.exports = merge(common, {
    target: ['web'],
    entry: {
        app: [
            path.resolve(JS_DIR, 'index.js'),
            path.resolve(CSS_DIR, 'site.scss'),
        ],
    },
    output: {
        path: path.resolve(BUILD_DIR, 'es6'),
        publicPath: '/ui/es6/',
        filename: 'bundle.js',
        clean: true,
    },
    cache: false,
    module: {
        rules: [
            {
                test: /\.js(x?)$/,
                include: [ES6_DIR, JS_DIR],
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            presets: ['@babel/preset-react'],
                            plugins: [],
                        },
                    },
                ],
            },
        ],
    },
    plugins: [
        new RemovePlugin({
            before: {
                include: [BUILD_DIR],
                log: false,
            },
        }),
        new MiniCssExtractPlugin({
            filename: '../css/site.min.css',
        }),
        // new BundleAnalyzerPlugin(),
    ],
});
