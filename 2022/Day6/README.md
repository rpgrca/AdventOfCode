## Day 6: Tuning Trouble

The preparations are finally complete; you and the Elves leave camp on foot and begin to make your way toward the **star** fruit grove.

As you move through the dense undergrowth, one of the Elves gives you a handheld _device_. He says that it has many fancy features, but the most important one to set up right now is the _communication system_.

However, because he's heard you have *significant experience dealing with signal-based systems*, he convinced the other Elves that it would be okay to give you their one malfunctioning device - surely you'll have no problem fixing it.

As if inspired by comedic timing, the device emits a few colorful sparks.

To be able to communicate with the Elves, the device needs to _lock on to their signal_. The signal is a series of seemingly-random characters that the device receives one at a time.

To fix the communication system, you need to add a subroutine to the device that detects a _start-of-packet marker_ in the datastream. In the protocol being used by the Elves, the start of a packet is indicated by a sequence of _four characters that are all different_.

The device will send your subroutine a datastream buffer (your puzzle input); your subroutine needs to identify the first position where the four most recently received characters were all different. Specifically, it needs to report the number of characters from the beginning of the buffer to the end of the first such four-character marker.

[Read all](https://adventofcode.com/2022/day/6)