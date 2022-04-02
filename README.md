# Gaku Gym

Gaku Gym is primarily a spaced-repetition-system (SRS) application. It is realized as a modern 
web-app and aims to provide a unified experience across devices while side stepping
the need to sync between them because the data is centrally located serverside. The downside
of course is that you must host Gaku Gym somewhere, which is likely to be an obstacle for 
many users.  

On Gaku Gym's roadmap are features such as note-taking and the ability to serve as a 
content respository of learning materials.

## Development Status

Gaku Gym is currently in a pre-alpha stage and is therefore not currently suitable for general use.

## Running Gaku Gym

Gaku Gym is a Blazor/ASP.Net Core application written in C#, so in order to build and run
it you will need the .NET 6 toolchain. Assuming you have that already installed, executing

`dotnet publish` 

in the root solution directory will build and prepare the project for deployment. The resulting
build artifacts will be found under Server/bin/Debug/net6.0/publish. The contents of this 
folder can then be hosted in your web-server of choice (IIS, Apache, Ngnix, etc).

The Settings.json "SecurityPasswordHash" will need to be updated to a bcrypt hash value of your 
choosing. This can be generated with `BCrypt.Net.BCrypt.HashPassword("<desired password here>")`.

## License

Gaku Gym is available under a source-available license. The source is available for people 
to compile and run Gaku Gym for personal, non-commercial use; but not to distribute, modify, 
or create derivative works. See LICENSE.txt for the full license verbiage (as these remarks
do not constitute the license itself).

As the project moves along further Gaku Gym may change to a more permissive (open source) 
license.

---

Copyright (c) 2022, Matthew Scott McNabb - All rights reserved.