
      function change_url(new_url)
      {
        console.log(new_url);
        window.location=new_url;
      }

      function add_background_player(playername)
      {
    var holder = document.createElement("div");
        holder.id=playername;
        holder.classList.add("backgorund_player");
        var name = document.createElement("h5");
        name.innerText=playername;      
        name.classList.add("bg_player_name");
        holder.appendChild(name);
        document.getElementById("players_section").appendChild(holder);
      }

        
      
      function remove_backround_key(key_id)
      {
        document.getElementById(key_id).style.display="none";

      }

      function add_background_player_key(player,faces,id)
       {
        var key= document.createElement("div");
         key.classList.add("bg_player_key");
         key.id=id;
        for(var a of faces)
         {
            var img= document.createElement("img");
           img.src="/Assets/"+a+".png";
           key.appendChild(img);
         }

         document.getElementById(player).appendChild(key);
        }
      
      function hide_backround_player(player)
      {

         document.getElementById(player).style.display="none";
      }

      function show_backround_player(player)
{

         document.getElementById(player).style.display="flex";
}

        function change_name(a)
        {
            var text = document.getElementById("player_name");                       
            text.innerText=`Turno de : ${a}`;
        }

        function activateToogle(message)
        {
            var not = document.getElementById("toast");
            document.getElementById("toast_text").innerText=message;
            not.style.display="block";
        }

        function ToogleToast()
        {
            document.getElementById("toast").style.display="none";
        }

        function remove_playerKeys(playername)
        {
            var mini_container = document.getElementById(playername);
            var container = document.getElementById("player_keys");
            var keys = document.getElementsByClassName("player_key");
            for(var a of keys )
            {
               container.removeChild(a);
            }
        }

        function add_to_center(faces)
        {
            var board = document.getElementById("center");
            var key=create_board_key(faces);
            board.appendChild(key);
        }
        
        function add_to_board(faces,front,board_numb)
        {
            var board = document.getElementById(`board_${board_numb}`);
            var key=create_board_key(faces);
            if(front)
            {
                if(board.firstChild!=null){
                board.insertBefore(key,board.firstChild);
                    return;
                }
            }
                board.appendChild(key);
        }

        function create_board_key(faces)        
        {
            var key = document.createElement("div");
            key.classList.add("onboardKey");
            for(var a of faces)
            {
                var image = document.createElement("img");
                image.classList.add("card-img");
                image.src=`Assets/${a}.png`;
                image.alt=a;
                key.appendChild(image);
            }
            return key;
        }

        function create_decoration_key(faces)        
        {
            var key = document.createElement("div");
            key.classList.add("player_key");
            for(var a of faces)
            {
                var image = document.createElement("img");
                image.classList.add("key_img");
                image.src=`Assets/${a}.png`;
                key.appendChild(image);
            }
            return key;
        }
        function Add_playerKeys(faces)
        {

            var container = document.getElementById("player_keys").appendChild(create_decoration_key(faces));
        }

