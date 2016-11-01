# SerilogPoC

A very simple proof-of-concept application, demonstrating the usefulness of Serilog and Seq.

I've broken this down into the following commits:

1. [Use of static logging configuration with Serilog.](https://github.com/arggrande/SerilogPoC/commit/d4a51457e9430e4dd3c7cd4202d8ef1df9296bc6) (initial commit, so this is a bit noisy)
2. [Added ILogger injection via Autofac, with request correlation via SerilogWeb.Classic](https://github.com/arggrande/SerilogPoC/commit/a57139df2ead6f1b8199173f5128479b4a0958b2)
3. [Demonstrate use of SelfLog to output Serilog internal exceptions, using a bad Seq URL.](https://github.com/arggrande/SerilogPoC/commit/5d7b765f9c266bdebe0bee7a2bae4732c18ae646)
4. [Added in a demonstration of the use of ContextProperties, with Destructuring example.](https://github.com/arggrande/SerilogPoC/commit/7e2a5a06cbc7913b762631b2a00eb493db4328c8)

This repository was created because of a blog post I've written, going into details on how this all works. You can check out the blog post [here](https://pendingtechnical.azurewebsites.net/on-seq-and-the-usefulness-of-serilog/)

PRs welcome if there are any mistakes!
