i, s, l = 1, "", 0

while True:
	si = str(i)
	s += si
	l += len(si)
	i += 1
	if l > 1000000:
		#print s[0]
		break

print int(s[1-1]) * int(s[10-1]) * int(s[100-1]) * int(s[1000-1]) * int(s[10000-1]) * int(s[100000-1]) * int(s[1000000-1])

