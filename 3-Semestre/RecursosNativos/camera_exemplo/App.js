import { StatusBar } from 'expo-status-bar';
import { Image, Modal, StyleSheet, Text, TouchableOpacity, View } from 'react-native';

import { Camera, CameraType } from 'expo-camera';
import { useEffect, useState, useRef } from 'react';

import { AntDesign } from '@expo/vector-icons';

export default function App() {

  const [tipoCamera, setTipoCameta] = useState(CameraType.back)
  const [openModal, setOpenModal] = useState(false)
  const [foto, setFoto] = useState(null)

  const cameraRef = useRef(null)

  useEffect(() => {
    ( async () => {
      const {status: cameraStatus} = await Camera.requestCameraPermissionsAsync()
    })();
  }, [])

  const CaptureFoto = async () => {

    if(cameraRef){
      const photo = await cameraRef.current.takePictureAsync()

      setOpenModal(true)
      setFoto(photo.uri)
      

      console.log(photo);
    }
  }

  return (
    <View style={styles.container}>
      <Camera
        ref={cameraRef}
        style={styles.camera}
        ratio='15:9'
        type={tipoCamera}
      >
        <View 
          style={styles.viewFlip}
        >
          <TouchableOpacity
            style={styles.btnFlip}
            onPress={() => setTipoCameta(tipoCamera == CameraType.front ? CameraType.back : CameraType.front)}
          >
            <Text Style={styles.txtFlip}>Trocar</Text>
          </TouchableOpacity>
        </View>
      </Camera>
      <TouchableOpacity
        style={styles.btnCapture}
        onPress={CaptureFoto}
      >
       <AntDesign name="camera" size={23} color="#FFF"/>
      </TouchableOpacity>

      <Modal
        animationType='slide'
        transparent={false}
        visible={openModal}
      >
        <View
          style={{flex: 1, margin: 20, justifyContent: "center", alignItems: "center"}}
        >
          {/* Controles da foto */}
          <View
            style={{margin: 10, flexDirection: "row"}}
          ></View>

          <Image
            style={{width: "100%", height:500, borderRadius: 15}}
            source={{uri: foto}}
          />

          <Text onPress={() => setOpenModal(false)}>Fechar</Text>
        </View>
      </Modal>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
  camera: {
    flex: 1,
    height: "80%",
    width: "100%"
  },
  viewFlip: {
    flex: 1,
    backgroundColor: "transparent",
    flexDirection: "row",
    alignItems: "flex-end",
    justifyContent: "center"
  },
  btnFlip: {
    padding: 10,
    backgroundColor: "white",
    borderRadius: 10,
    marginBottom: 15
  },
  txtFlip: {
    fontSize: 20,
    marginBottom: 20,
  },
  btnCapture: {
    padding: 20,
    margin: 20,
    borderRadius: 10,
    backgroundColor: "#8775F0",
    justifyContent: "center",
    alignItems: "center"
  }
});
