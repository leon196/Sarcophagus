#!/bin/sh

spd=1

while [ $spd -le 2 ]
do
	seq=0
	while [ $seq -le 14 ]
	do
	   make file SN=$seq SPEED=$spd
	   seq=`expr $seq + 1`
	done
	spd=`expr $spd + 1`
done
