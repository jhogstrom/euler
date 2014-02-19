import itertools

combinations = (900, 
				810, 
				711, 720, 
				630, 621, 603,
				540, 531, 522)

comboset = set()
for c in combinations:
	comboset = comboset.union(itertools.permutations(list(str(c))))

for e in sorted(list(comboset)):
	print e
#print comboset, len(comboset)
print 17 * 45

def getnums():
	return ["{0:0>3}".format(i) for i in range(1000)]
	# nums = []
	# for i in range(1000):	
	# 	nums.append(list("{0:0>3}".format(i)))


def sumnum(c):
	return sum([int(n) for n in c])

nums = [c for c in getnums() if sumnum(c) > 9]
print len(nums)
nums = [c for c in getnums() if sumnum(c) <= 9]
n2 = []
for i in range(10):
	n2 = n2 + [str(i) + s[:2] for s in nums]

print n2	
print len(n2)

	
#print nums
exit()