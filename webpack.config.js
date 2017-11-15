var path = require("path");
var webpack = require("webpack");
var fableUtils = require("fable-utils");

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
  presets: [["es2015", { "modules": false }]],
  plugins: [["transform-runtime", {
    "helpers": true,
    // We don't need the polyfills as we're already calling
    // cdn.polyfill.io/v2/polyfill.js in index.html
    "polyfill": false,
    "regenerator": false
  }]]
});

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
  devtool: "source-map",
  entry: resolve('./src/client/client.fsproj'),
  output: {
    filename: 'bundle.js',
    path: resolve('./public'),
  },
  resolve: {
    modules: [
      "node_modules", resolve("./node_modules/")
    ]
  },
  devServer: {
    contentBase: resolve('./public'),
    port: 8080,
    hot: true,
    inline: true,
    proxy: {
      '/api/*': {
        target: "http://localhost:9000",
        changeOrigin: true
      }
    }
  },
  plugins : isProduction ? [] : [
      new webpack.HotModuleReplacementPlugin(),
      new webpack.NamedModulesPlugin()
  ],
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      },
      {
        test: /\.scss$/,
        exclude: /node_modules/,
        use: [
          {
            loader: 'style-loader'
          },
          {
            loader: 'css-loader',
            options: {
              modules: true,
              localIdentName: '[path][name]__[local]--[hash:base64:5]'
            }
          },
          { loader: "sass-loader" }
        ]
       },
       {
        test: /\.jpg$/,
        exclude: /node_modules/,
        use: [
          {
            loader: 'file-loader'
          }
        ]
       }
    ]
  }
};
