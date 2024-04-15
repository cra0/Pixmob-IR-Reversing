# Reversing Pixmob IR LEB Wristband

## Overview

While numerous repositories have explored and successfully reverse-engineered various aspects of the Pixmob IR LEB wristband, I have opted to delve into the EEPROM myself. This personal investigation aims to broaden the existing knowledge base about the device's functionality.

![pcb](docs/pixmob-pcb-v2_3_r1.jpg)

### EEPROM dump
The [/dumps](dumps/) directory contains what I've extracted from the SMD eeprom labeled **C24C02** from a few wristbands.

My soldering skills are pretty shit however I managed to connect some wires to it. After using the [Bus Pirate 5](https://hardware.buspirate.com/) I successfully dumped the contents.

![c24c02 SMD](docs/eeprom-dmp1.jpg)

### Memory structure

TBC

## Other projects

1. [PixMob IR (and RF!) Reverse Engineering Project](https://github.com/danielweidman/pixmob-ir-reverse-engineering)
2. [PixMob_waveband reverse engineering](https://github.com/sueppchen/PixMob_waveband/tree/main)
3. [ndp2019-wristband-teardown](https://github.com/yeokm1/ndp2019-wristband-teardown)