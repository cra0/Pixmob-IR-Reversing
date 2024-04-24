# Reversing Pixmob IR LEB Wristband

## Overview

While numerous repositories have explored and successfully reverse-engineered various aspects of the Pixmob IR LEB wristband, I have opted to delve into the EEPROM myself. This personal investigation aims to broaden the existing knowledge base about the device's functionality.

![pcb](docs/pixmob-pcb-v2_3_r1.jpg)


### MCU

TO_BE_FILLED_OUT
![mcu](docs/mcu.jpg)


### EEPROM dump
The [/dumps](dumps/) directory contains what I've extracted from the SMD eeprom labeled **C24C02** from a few wristbands.

My soldering skills are pretty shit however I managed to connect some wires to it. After using the [Bus Pirate 5](https://hardware.buspirate.com/) I successfully dumped the contents.

![c24c02 SMD](docs/eeprom-dmp1.jpg)

I got my hands on another few samples to mess with shortly after. These I connected proper probes to and also dumped it's contents which appears to be the same.

![c24c02 SMD](docs/eeprom-dmp2.jpg)

![AK13L SMD](docs/eeprom-dmp3.jpg)

[Data Sheet](docs/AT24C02.pdf)

#### Behaviour

When the PixMob is provided power the MCU appears to wipe the EEPROM and write a default state to it.

```hex
09 00 00 01 00 00 00 00 01 01 01 01 01 01 01 01
00 BF 00 BF 00 BF 60 1F 00 60 BF 1F 00 00 BF BF
BF 00 BF 7E BF 00 00 BF BF BF 00 7E 60 BF 00 1F
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 BF
BF BF 3D 00 00 00 1E 1E 1E 70 06 FF FF FF FF FF
```

### Memory structure

TO_BE_FILLED_OUT

![010editor_sc](docs/eeprom_struct.png)


## Other projects

1. [PixMob IR (and RF!) Reverse Engineering Project](https://github.com/danielweidman/pixmob-ir-reverse-engineering)
2. [PixMob_waveband reverse engineering](https://github.com/sueppchen/PixMob_waveband/tree/main)
3. [ndp2019-wristband-teardown](https://github.com/yeokm1/ndp2019-wristband-teardown)