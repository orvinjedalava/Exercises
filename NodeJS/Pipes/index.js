const fs = require("node:fs");
const zlib = require("node:zlib");

const gzip = zlib.createGzip();

const readableStream = fs.createReadStream("./file.txt", { 
    encoding: "utf-8",
    highWaterMark: 2
});

// readable stream -> transform stream -> writable stream
readableStream.pipe(gzip).pipe(fs.WriteStream("./file2.txt.gz"));

// readable stream -> writable stream
const writeableStream = fs.createWriteStream("./file2.txt");
readableStream.pipe(writeableStream);
