from az.cli import az  
def execute_cmd(cmd):
   try:  
     exit_code, result, logs = az(cmd)  
     if exit_code == 0:  
       return result  
     else:  
       print(logs)  
   except Exception as e:  
     print("Error occured!! While running the CLI command. {}".format(e))  
   
example_cmd = "az synapse trigger list --workspace-name dcazsqldfab01".format(Synapse,rg-lam-usw-dfab-dev-eng-o001)
boot_diagnostics = execute_cmd(example_cmd)