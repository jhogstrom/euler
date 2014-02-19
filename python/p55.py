def isLychrel(n):
	n += int(str(n)[-1::-1])
	for i in range(50):
		s = str(n)
		sr = s[::-1]
		if s == sr:
			return False
		n += int(sr) 
	return True


# print "abcdef"[-1::-1]
# print isLychrel(4994	)
# exit()

l = 0
print [isLychrel(i) for i in range(1,10000)].count(True)
	# if isLychrel(i):
	# 	l +=1

print l