def get_all_files root
	list = Dir::entries(root)
	list = list - [".", ".."]
	
	list.each do |elm|
		type = File::ftype(root + elm)
		
		if(type == "directory")
			new_root = root + elm + "/"
			get_all_files new_root do |e|
				yield e
			end
		elsif(type == "file")
			yield root + elm
		end
	end
end

root = "./"
sum = 0

get_all_files root do |e|
	file = File.open(e)
	lines_count = file.read.count("\n")
	sum = sum + lines_count
	file.close
end

p sum
#p Dir::entries("./")