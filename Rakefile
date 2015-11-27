task default: %w[test]

task :test do
  Dir.entries('src').select do |entry| 
  	if File.directory? File.join('src', entry) and !(entry =='.' || entry == '..') and entry.include? "Tests"
  		Dir.chdir File.join('src', entry)
  		sh "dnx test"
		Dir.chdir "../../"
	end
  end
end

task :restore do
  Dir.entries('src').select do |entry| 
  	if File.directory? File.join('src', entry) and !(entry =='.' || entry == '..')
  		Dir.chdir File.join('src', entry)
  		sh "dnu restore"
		Dir.chdir "../../"
	end
  end
end

task :build do
  Dir.entries('src').select do |entry| 
  	if File.directory? File.join('src', entry) and !(entry =='.' || entry == '..')
  		Dir.chdir File.join('src', entry)
  		sh "dnu build"
		Dir.chdir "../../"
	end
  end
end