## Day 10: Cathode-Ray Tube

You avoid the ropes, plunge into the river, and swim to shore.

The Elves yell something about meeting back up with them upriver, but the river is too loud to tell exactly what they're saying. They finish crossing the bridge and disappear from view.

Situations like this must be why the Elves prioritized getting the communication system on your handheld device working. You pull it out of your pack, but the amount of water slowly draining from a big crack in its screen tells you it probably won't be of much immediate use.

Unless, that is, you can design a replacement for the device's video system! It seems to be some kind of **cathode-ray tube** screen and simple CPU that are both driven by a precise _clock circuit_. The clock circuit ticks at a constant rate; each tick is called a _cycle_.

Start by figuring out the signal being sent by the CPU. The CPU has a single register, X, which starts with the value 1. It supports only two instructions:

- _addx V_ takes _two cycles_ to complete. After two cycles, the X register is increased by the value _V_. (_V_ can be negative.)
- _noop_ takes _one cycle_ to complete. It has no other effect.

The CPU uses these instructions in a program (your puzzle input) to, somehow, tell the screen what to draw.

[Read all](https://adventofcode.com/2022/day/10)