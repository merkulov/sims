module.exports = {
    entry: "./app.ts",
    output: {
        filename: "bundle.js"
    },
    watch: true,
    module: {
        loaders: [
            {
                test: /.ts$/,
                loader: "ts-loader"
            }
        ]
    }
}