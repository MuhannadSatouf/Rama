const MiniCssExtractPlugin = require('mini-css-extract-plugin');

const path = require('path');
const ROOT = path.resolve(__dirname, '../');
const BUILD_DIR = path.resolve(ROOT, '../wwwroot/ui');

module.exports = {
    context: ROOT,
    output: {
        path: BUILD_DIR,
        publicPath: '/ui/',
        filename: '[name].js',
        clean: true,
    },
    devtool: 'source-map',
    cache: false,
    module: {
        rules: [
            {
                test: /\.css$/,
                include: /node_modules/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader,
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true,
                        },
                    },
                ],
            },
            {
                test: /\.scss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader,
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            sourceMap: true,
                        },
                    },
                    {
                        loader: 'resolve-url-loader',
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: true,
                        },
                    },
                ],
            },
            {
                test: /\.svg$/,
                exclude: /(\/fonts)/,
                type: 'asset/inline',
            },
            {
                test: /\.(png|jpg|jpeg|gif|ico)/i,
                exclude: /(\/fonts)/,
                type: 'asset/resource',
            },
            {
                test: /\.(woff(2)?|ttf|eot|svg)/i,
                include: [/fonts/, /node_modules/],
                type: 'asset/resource',
            },
        ],
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: '[name].css',
        }),
    ],
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
    },
};
