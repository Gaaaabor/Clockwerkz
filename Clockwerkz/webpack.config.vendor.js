const path = require('path');
const webpack = require('webpack');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        mode: isDevBuild ? 'development' : 'production',
        stats: 'errors-only',
        devtool: 'inline-source-map',
        entry: {
            main: path.join(__dirname, '/ClientApp/boot.tsx')
        },
        resolve: {
            extensions: ['.js', '.ts', '.tsx']
        },
        output: {
            path: path.join(__dirname, 'wwwroot/dist'),
            filename: '[name].js',
            publicPath: '/dist/'
        },

        module: {
            rules: [
                //{ test: /\.css$/, use: ['style-loader', 'css-loader'], include: path.join(__dirname, 'ClientApp') },
                {
                    test: /\.css$/,
                    include: path.join(__dirname, 'ClientApp/'),
                    use: [
                        'style-loader',
                        {
                            loader: 'typings-for-css-modules-loader',
                            options: {
                                modules: true,
                                namedExport: true,
                                camelCase: true
                            }
                        }
                    ]
                },
                { test: /\.tsx?$/, loader: 'ts-loader' },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' }
            ]
        },
        plugins: [
            new CheckerPlugin(),
            new webpack.ProvidePlugin({ Popper: ['popper.js', 'default'] })
        ].concat(isDevBuild
            ? [
                // Plugins that apply in development builds only
                new webpack.SourceMapDevToolPlugin({
                    filename: '[file].map', // Remove this line if you prefer inline source maps
                    moduleFilenameTemplate: path.relative(bundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk                
                })
            ]
            : [
                // Plugins that apply in production builds only
                //new webpack.optimization.minimize.UglifyJsPlugin(),
                //new ExtractTextPlugin('site.css')
            ])
    }];
};