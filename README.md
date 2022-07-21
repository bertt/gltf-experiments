# gltf-experiments

Various glTF experiments

- using PbrSpecularGlossiness shader;

- drawing pointclouds

![image](https://user-images.githubusercontent.com/538812/180217176-bb4d10e7-8e34-4b10-97c7-cb48d5eb5ffa.png)

- drawing animations

## Pointclouds

data preparation:

Download a laz file kaartblad from Utrecht 

```
$ wget https://geodata.nationaalgeoregister.nl/ahn3/extract/ahn3_laz/C_31HZ2.LAZ
```

Crop laz file using pdal crop with json:

```
{ "pipeline":[ "/data/C_31HZ2.LAZ", { "type":"filters.crop", "bounds":"([136356.6585, 136922.3581],[ 455832.7428, 456107.1495])" }, "/data/utrecht.LAZ" ] }
```

```
$ pdal pipeline crop.json
```
