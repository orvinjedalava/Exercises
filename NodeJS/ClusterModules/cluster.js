const http = require("node:http");
const cluster = require("node:cluster");
const numCPUs = require('node:os').cpus().length;
cluster.schedulingPolicy = cluster.SCHED_RR;

if (cluster.isMaster) {
    console.log(`Master process: ${process.pid} is running`);
    cluster.fork();
    cluster.fork();
} else {
    console.log(`Worker ${process.pid} started`);
    const server = http.createServer((req, res) => {
        if (req.url === "/") {
            res.writeHead(200, { "Content-Type": "text/plain"});
            res.end("Home page");
        } else if (req.url === "/slow-page") {
            for (let i = 0; i < 6000000000; i++) {}
            res.writeHead(200, { "Content-Type": "text/plain"});
            res.end("Slow page");
        }
    });

    server.listen(8000, () => console.log("Server is running on port 8000"));
}