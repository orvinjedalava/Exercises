const crypto = require("node:crypto");

// doesn't work on windows
process.env.UV_THREADPOOL_SIZE = 5;

const MAX_CALLS = 5;

const start = Date.now();

for (let i = 0; i < MAX_CALLS; i++) {
    crypto.pbkdf2("password","salt", 100000, 512, "sha512", () => {
        console.log(`Hash: ${i}`, Date.now() - start);
    });
}
// crypto.pbkdf2Sync("password","salt", 100000, 512, "sha512");
// crypto.pbkdf2Sync("password","salt", 100000, 512, "sha512");
// crypto.pbkdf2Sync("password","salt", 100000, 512, "sha512");
// console.log("Hash: ", Date.now() - start);