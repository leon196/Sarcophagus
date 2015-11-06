noise:
	gcc -D SEQ=6 -D SPEED=1 -D CYCLEMODE=CONTINUE -o bin/blast blast.c && bin/blast | aplay
	
	
file:
	gcc -D SEQ=$(SN) -D SPEED=$(SPEED) -D CYCLEMODE=END -o bin/blast blast.c
	bin/blast > samples/snd_$(SPEED)_$(SN).raw
	sox -r 8000 -e unsigned -b 8 -c 1 samples/snd_$(SPEED)_$(SN).raw samples/snd_$(SPEED)_$(SN).wav
